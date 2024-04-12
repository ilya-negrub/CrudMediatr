namespace DAL.Core.Interfaces
{
    public interface IMockupLocalRepository<TEntity>
    {
        public IQueryable<TEntity> GetQuery();
    }
}
