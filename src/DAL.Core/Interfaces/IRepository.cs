namespace DAL.Core.Interfaces
{
    /// <summary>
    /// Репозиторий данных.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Возвращает запрос к данным сущности.
        /// </summary>
        public IQueryable<TEntity> GetQuery();

        /// <summary>
        /// Добавляет сущность в хранилище.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        public void Add(TEntity entity);

        /// <summary>
        /// Удаляет сущность из хранилища.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        public void Delete(TEntity entity);

        /// <summary>
        /// Обновляет сущность в хранилище.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        public void Update(TEntity entity);
    }
}
