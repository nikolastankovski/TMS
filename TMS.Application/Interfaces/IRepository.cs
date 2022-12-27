using TMS.Domain;
using TMS.Domain.CustomEntities;

namespace TMS.Application.Interfaces
{
    public interface IRepository<T> : IViewRepository<T> where T : BaseEntity
    {
        ActionResponse Create(T entity);
        ActionResponse Create(List<T> entities);
        Task<ActionResponse> CreateAsync(T entity);
        Task<ActionResponse> CreateAsync(List<T> entities);

        ActionResponse Delete(long id);
        ActionResponse Delete(List<long> ids);
        Task<ActionResponse> DeleteAsync(long id);
        Task<ActionResponse> DeleteAsync(List<long> ids);

        ActionResponse Update(T entity);
        ActionResponse Update(List<T> entities);
        Task<ActionResponse> UpdateAsync(T entity);
        Task<ActionResponse> UpdateAsync(List<T> entities);

    }
}
