using CrudMediatr.Core.Expressions.Interfaces;
using DAL.Core.Interfaces;
using MediatR;

namespace CrudMediatr.Core.RequestHandlers
{
    /// <summary>
    /// Реализация обработки запроса на обновление строки.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <typeparam name="TModel">Тип параметров запроса.</typeparam>
    public class UpdateRequestHandler<TEntity, TModel> : IRequestHandler<TModel>
        where TModel : IRequest
    {
        private readonly IRepository<TEntity> _repositoryEntity;
        private readonly IUpdateExpressions<TEntity, TModel> _expressions;

        public UpdateRequestHandler(
            IRepository<TEntity> repositoryEntity,
            IUpdateExpressions<TEntity, TModel> expressions)
        {
            _repositoryEntity = repositoryEntity;
            _expressions = expressions;
        }

        /// <inheritdoc/>
        public Task Handle(TModel model, CancellationToken cancellationToken)
        {
            var entities = _repositoryEntity.GetQuery()
                .Where(_expressions.GetPredicate(model))
                .Select(_expressions.GetSelector(model))
                .ToArray();

            foreach (var entity in entities)
            {
                _repositoryEntity.Update(entity);
            }

            return Task.CompletedTask;
        }
    }
}
