using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Pagination
{
    public static class PaginationExtension
    {
        public async static Task<PagedListDataResponse<T>> PagedListResponse<T>(this IQueryable<T> source, int pageSize, int pageNumber) where T : EntityDTO
        {
            IEnumerable<T> datas = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            int totalDatas = source.Count();

            return new(totalDatas, pageNumber, pageSize, datas);
        }
    }
}
