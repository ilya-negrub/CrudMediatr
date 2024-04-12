using CrudMediatr.Core.Expressions.Interfaces;
using DAL.Core.Interfaces;
using MediatR;

namespace CrudMediatr.Core.RequestHandlers
{
    /// <summary>
    /// Реализация обработки запроса на удаление строки.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <typeparam name="TModel">Тип параметров запроса.</typeparam>
    public class DeleteRequestHandler<TEntity, TModel> : IRequestHandler<TModel>
        where TModel : IRequest
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IDeleteExpressions<TEntity, TModel> _expressions;

        public DeleteRequestHandler(
            IRepository<TEntity> repository,
            IDeleteExpressions<TEntity, TModel> expressions)
        {
            _repository = repository;
            _expressions = expressions;
        }

        /// <inheritdoc/>
        public Task Handle(TModel model, CancellationToken cancellationToken)
        {
            var entities = _repository.GetQuery()
                .Where(_expressions.GetPredicate(model))
                .ToArray();

            foreach (var entity in entities)
            {
                _repository.Delete(entity);
            }

            return Task.CompletedTask;
        }
    }
}
