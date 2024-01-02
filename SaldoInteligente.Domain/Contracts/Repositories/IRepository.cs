namespace SaldoInteligente.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Find(params object[] keys);
    }
}
