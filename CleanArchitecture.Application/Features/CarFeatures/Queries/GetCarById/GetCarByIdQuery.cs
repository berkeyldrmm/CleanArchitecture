using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Dtos.EntityDtos.Car;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetCarById
{
    public sealed record GetCarByIdQuery(string Id) : IRequest<DataResponse<CarDetailDTO>>;
}
