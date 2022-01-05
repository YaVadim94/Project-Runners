using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectRunners.Data;
using ProjectRunners.Data.Models.Bases;

namespace ProjectRunners.Application.Extensions
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