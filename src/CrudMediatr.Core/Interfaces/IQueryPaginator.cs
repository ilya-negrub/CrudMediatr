namespace CrudMediatr.Core.Interfaces
{
    /// <summary>
    /// Интерфейс разделения запроса на страницы.
    /// </summary>
    /// <typeparam name="TModel">Тип модели выходных данных.</typeparam>
    public interface IQueryPaginator<TModel>
    {
        /// <summary>
        /// Разделяет запрос данных на страницы.
        /// </summary>
        /// <param name="query">Запрос данных.</param>
        /// <param name="request">Экземпляр запроса на чтение для разделения на страницы.</param>
        public IQueryable<TModel> Paging(IQueryable<TModel> query, IPagingRequest request);
    }
}
