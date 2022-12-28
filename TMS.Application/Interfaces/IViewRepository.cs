using System.Linq.Expressions;
using TMS.Domain;

namespace TMS.Application.Interfaces
{
    public interface IViewRepository<T> where T : BaseEntity
    {
        List<T> Get(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, int, T>>? select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = ""
        );
        Task<List<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, int, T>>? select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = ""
        );
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
        T? GetById(object? id);
        Task<T?> GetByIdAsync(object? id);
    }
}
