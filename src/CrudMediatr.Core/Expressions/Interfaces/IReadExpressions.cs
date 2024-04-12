using System.Linq.Expressions;

namespace CrudMediatr.Core.Expressions.Interfaces
{
    /// <summary>
    /// Реализует выражения Read-операции.
    /// </summary>
    /// <typeparam name="TEntity">Сущность.</typeparam>
    /// <typeparam name="TModel">Модель данных.</typeparam>
    /// <typeparam name="TRequest">Запрос.</typeparam>
    public interface IReadExpressions<TEntity, TModel, TRequest>
    {
        /// <summary>
        /// Условия отбора данных из репозитория сущности.
        /// </summary>
        /// <param name="request">Запрос.</param>
        public Expression<Func<TEntity, bool>> GetPredicate(TRequest request);

        /// <summary>
        /// Возвращает выражение преобразования <see cref="TEntity"/> в <see cref="TModel"/>.
        /// </summary>
        /// <param name="model">Модель данных.</param>
        public Expression<Func<TEntity, TModel>> GetSelector(TRequest request);
    }
}
