using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.Application.Interfaces;
using TMS.Domain;
using TMS.Domain.Constants;
using TMS.Domain.CustomEntities;
using TMS.Infrastructure.Data;
using TMS.Infrastructure.Repositories;

namespace TMS.Repositories
{
    public class Repository<T> : ViewRepository<T>, IRepository<T> where T : BaseEntity
    {
        private readonly TMSDbContext _context;
        internal new DbSet<T> _entity;
        protected new readonly ILogger<T> _logger;

        public Repository(TMSDbContext context, ILogger<T> logger) : base( context, logger )
        {
            _context = context;
            _entity = _context.Set<T>();
            _logger = logger;
        }

        public virtual ActionResponse Create(T entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNull };

            try
            {
                entity.CreatedOn = DateTime.Now;
                _entity.Add(entity);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual ActionResponse Create(List<T> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNull };


            try
            {
                entities.ForEach(x => x.CreatedOn = DateTime.Now);
                _entity.AddRange(entities);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> CreateAsync(T entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNull };

            try
            {
                entity.CreatedOn = DateTime.Now;
                await _entity.AddAsync(entity);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> CreateAsync(List<T> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNull };

            try
            {
                entities.ForEach(x => x.CreatedOn = DateTime.Now);
                await _entity.AddRangeAsync(entities);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual ActionResponse Delete(long id)
        {
            T? entity = GetById(id);

            if(entity == null)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNotFound };

            try
            {
                _entity.Remove(entity);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public ActionResponse Delete(List<long> ids)
        {
            List<T> entities = new List<T>();
            List<long> missingEntities = new List<long>();

            foreach(var id in ids)
            {
                T? entity = GetById(id);

                if (entity == null)
                {
                    missingEntities.Add(id);
                    continue;
                }

                entities.Add(entity);
            }

            missingEntities.TryGetNonEnumeratedCount(out int count);

            if (count > 0)
                return new ActionResponse() { IsSuccess = false, Message = $"Error! Missing entities: {missingEntities.ToString()}" };

            try
            {
                _entity.RemoveRange(entities);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };

            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> DeleteAsync(long id)
        {
            T? entity = await GetByIdAsync(id);

            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNotFound };

            try
            {
                _entity.Remove(entity);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> DeleteAsync(List<long> ids)
        {
            List<T> entities = new List<T>();
            List<long> missingEntities = new List<long>();

            foreach (var id in ids)
            {
                T? entity = await GetByIdAsync(id);

                if (entity == null)
                {
                    missingEntities.Add(id);
                    continue;
                }

                entities.Add(entity);
            }

            missingEntities.TryGetNonEnumeratedCount(out int count);

            if (count > 0)
                return new ActionResponse() { IsSuccess = false, Message = $"Error! Missing entities: {missingEntities.ToString()}" };

            try
            {
                _entity.RemoveRange(entities);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };

            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public ActionResponse Update(T entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNull };

            try
            {
                entity.UpdatedOn= DateTime.Now;
                _entity.Update(entity);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public ActionResponse Update(List<T> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNull };

            try
            {
                entities.ForEach(x => x.UpdatedOn = DateTime.Now);
                _entity.UpdateRange(entities);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> UpdateAsync(T entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNull };

            try
            {
                entity.UpdatedOn = DateTime.Now;
                _entity.Update(entity);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> UpdateAsync(List<T> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = RepoMessage.EntityNull };

            try
            {
                entities.ForEach(x => x.UpdatedOn = DateTime.Now);
                _entity.UpdateRange(entities);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = RepoMessage.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }
    }
}
