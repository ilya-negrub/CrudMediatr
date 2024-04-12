using DAL.Core.Interfaces;

namespace DAL.Core.Services
{
    /// <summary>
    /// Локальный репозиторий данных.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public class LocalRepository<TEntity> : IRepository<TEntity>
        where TEntity : IHaveId
    {
        private readonly List<TEntity> _data;

        public LocalRepository(IFactory factory)
        {
            if (_data != null)
            {
                return;
            }

            var mockupService = factory.Create<IMockupLocalRepository<TEntity>>();

            _data = mockupService != null
                ? mockupService.GetQuery().ToList()
                : new List<TEntity>();
        }

        /// <inheritdoc/>
        public IQueryable<TEntity> GetQuery()
        {
            return _data.AsQueryable();
        }

        /// <inheritdoc/>
        public void Add(TEntity entity)
        {
            _data.Add(entity);
        }

        /// <inheritdoc/>
        public void Delete(TEntity entity)
        {
            _data.Remove(entity);
        }

        /// <inheritdoc/>
        public void Update(TEntity entity)
        {
            var item = _data.FirstOrDefault(x => x.Id == entity.Id);

            if (item != null)
            {
                var index = _data.IndexOf(item);
                _data.RemoveAt(index);
                _data.Insert(index, entity);
            }
        }
    }
}
