using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Runners.Data;
using Project_Runners.Data.Models.Base;

namespace Project_Runners.Application.Extensions
{
    /// <summary>
    /// Методы расширения для <see cref="DataContext"/>
    /// </summary>
    public static class IQueryableExtensions
    {
        public static async Task<T> GetById<T>(this IQueryable<T> query, long id) where T : EntityBase => 
            await query.SingleOrDefaultAsync(r => r.Id == id) ?? throw new ArgumentException(nameof(T));
    }
}