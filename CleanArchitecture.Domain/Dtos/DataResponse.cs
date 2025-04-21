using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Dtos;

public record DataResponse<T>(T Value) : MessageResponse where T : EntityDTO;

public record PagedListDataResponse<T> : MessageResponse where T : EntityDTO
{
    public PagedListDataResponse(int totalDatas, int pageNumber, int pageSize, IEnumerable<T> datas)
    {
        this.TotalDatas = totalDatas;
        this.PageNumber = pageNumber;
        this.PageSize = pageSize;
        this.Datas = datas;
        TotalPage = (int)Math.Ceiling((decimal)totalDatas / pageSize);
        this.IsLastPage = pageNumber == TotalPage;
        this.IsFirstPage = pageNumber == 1;
    }
    public IEnumerable<T> Datas { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalDatas { get; set; }
    public int TotalPage { get; set; }
    public bool IsFirstPage { get; set; }
    public bool IsLastPage { get; set; }
}
