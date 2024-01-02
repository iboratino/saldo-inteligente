
using Microsoft.EntityFrameworkCore;
using SaldoInteligente.Domain.Contracts.Repositories;

namespace SaldoInteligente.Infrastructure.ORM
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
         where TContext : BankAccountContext, new()
         where TEntity : class, new()
    {

        protected readonly TContext _context;

        protected Repository(TContext context)
        {
            this._context = context;
            this._context.Database.SetCommandTimeout(100);
        }

        public TEntity Insert(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            catch (Exception dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("conflicted with the REFERENCE constraint "))
                    throw new Exception("Não permitido, registro com vínculos.");
                throw ex;
            }
            catch (Exception dbEx)
            {
                throw new Exception(dbEx.Message);
            }
        }

        public TEntity Find(params object[] keys)
        {
            var entity = _context.Set<TEntity>().Find(keys);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
    }
}
