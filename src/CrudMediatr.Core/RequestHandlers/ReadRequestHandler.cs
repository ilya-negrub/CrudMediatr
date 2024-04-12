using CrudMediatr.Core.Expressions.Interfaces;
using CrudMediatr.Core.Interfaces;
using CrudMediatr.Core.Models;
using DAL.Core.Interfaces;
using MediatR;

namespace CrudMediatr.Core.RequestHandlers
{
    /// <summary>
    /// Реализация обработки запроса на обновление строки.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <typeparam name="TModel">Тип модели выходных данных.</typeparam>
    /// <typeparam name="TRequest">Тип параметров запроса.</typeparam>
    public class ReadRequestHandler<TEntity, TModel, TRequest> : IRequestHandler<TRequest, ReadResultModel<TModel>>
        where TRequest : IReadRequest<TModel>
    {
        private readonly IRepository<TEntity> _repositoryEntity;
        private readonly IReadExpressions<TEntity, TModel, TRequest> _expressions;
        private IQueryPaginator<TModel> _queryPaginator;

        public ReadRequestHandler(
            IFactory factory,
            IRepository<TEntity> repositoryEntity,
            IReadExpressions<TEntity, TModel, TRequest> expressions)
        {
            _repositoryEntity = repositoryEntity;
            _expressions = expressions;
            _queryPaginator = factory.Create<IQueryPaginator<TModel>>();
        }

        /// <inheritdoc/>
        public Task<ReadResultModel<TModel>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var query = _repositoryEntity.GetQuery()
                .Where(_expressions.GetPredicate(request))
                .Select(_expressions.GetSelector(request));

            var totalCount = query.Count();
            var pageCount = 1;

            if (_queryPaginator != null && totalCount > request.PageSize)
            {
                query = _queryPaginator.Paging(query, request);
                pageCount = request.PageSize > 0
                    ? (int)Math.Ceiling(totalCount / (double)request.PageSize)
                    : 1;
            }

            var result = new ReadResultModel<TModel>(
                query.AsEnumerable(),
                totalCount,
                pageCount);

            return Task.FromResult(result);
        }
    }
}
