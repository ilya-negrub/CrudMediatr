using CrudMediatr.Core.Interfaces;

namespace CrudMediatr.Core.Paginators
{
    /// <summary>
    /// Реализация разделения запроса на страницы.
    /// </summary>
    /// <typeparam name="TModel">Тип модели выходных данных.</typeparam>
    public class QueryPaginator<TModel> : IQueryPaginator<TModel>
    {
        /// <inheritdoc/>
        public IQueryable<TModel> Paging(IQueryable<TModel> query, IPagingRequest request)
        {
            if (request == null)
            {
                return query;
            }

            if (request.PageIndex > 0)
            {
                query = query.Skip(request.PageIndex * request.PageSize);
            }

            if (request.PageSize > 0)
            {
                query = query.Take(request.PageSize);
            }

            return query;
        }
    }
}
