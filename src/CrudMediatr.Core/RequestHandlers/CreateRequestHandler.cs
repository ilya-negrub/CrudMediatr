using CrudMediatr.Core.Expressions.Interfaces;
using DAL.Core.Interfaces;
using MediatR;

namespace CrudMediatr.Core.RequestHandlers
{
    /// <summary>
    /// Реализация обработки запроса на создание строки.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    /// <typeparam name="TModel">Тип параметров запроса.</typeparam>
    public class CreateRequestHandler<TEntity, TModel> : IRequestHandler<TModel>
        where TModel : IRequest
    {
        private readonly IRepository<TEntity> _repositoryEntity;
        private readonly ICreateExpressions<TEntity, TModel> _expressions;

        public CreateRequestHandler(
            IRepository<TEntity> repositoryEntity,
            ICreateExpressions<TEntity, TModel> expressions)
        {
            _repositoryEntity = repositoryEntity;
            _expressions = expressions;
        }

        /// <inheritdoc/>
        public Task Handle(TModel model, CancellationToken cancellationToken)
        {
            var entity = _expressions.GetSelector(model).Compile()(model);
            _repositoryEntity.Add(entity);
            return Task.CompletedTask;
        }
    }
}
