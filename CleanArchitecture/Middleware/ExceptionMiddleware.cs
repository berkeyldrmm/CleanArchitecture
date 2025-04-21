
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repository;
using FluentValidation;

namespace CleanArchitecture.WebApi.Middleware;

public sealed class ExceptionMiddleware : IMiddleware
{
    private readonly IErrorLogRepository _errorLogRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ExceptionMiddleware(IErrorLogRepository errorLogRepository, IUnitOfWork unitOfWork)
    {
        _errorLogRepository = errorLogRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await ExceptionLogger(context.Request, ex);
            await ExceptionHandlerAsync(context, ex);
        }
    }

    private Task ExceptionHandlerAsync(HttpContext context, Exception ex)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        if (ex.GetType() == typeof(ValidationException))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            return context.Response.WriteAsync(new ValidationErrorDetails
            {
                Errors = ((ValidationException)ex).Errors.Select(s => s.ErrorMessage),
                StatusCode = context.Response.StatusCode
            }.ToString());
        }

        return context.Response.WriteAsync(new ErrorResult
        {
            StatusCode = context.Response.StatusCode,
            Message = ex.Message
        }.ToString());
    }

    private async Task ExceptionLogger(HttpRequest request, Exception ex)
    {
        ErrorLog errorLog = new ErrorLog
        {
            ErrorMessage = ex.Message,
            RequestPath = request.Path,
            RequestMethod = request.Method,
            StackTrace = ex.StackTrace,
            Timestamp = DateTime.Now
        };

        await _errorLogRepository.AddAsync(errorLog, default);
        await _unitOfWork.SaveChangesAsync();
    }
}
