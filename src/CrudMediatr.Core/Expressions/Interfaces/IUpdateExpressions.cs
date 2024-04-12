using System.Linq.Expressions;

namespace CrudMediatr.Core.Expressions.Interfaces
{
    /// <summary>
    /// Реализует выражения Update-операции.
    /// </summary>
    /// <typeparam name="TEntity">Сущность.</typeparam>
    /// <typeparam name="TModel">Модель данных.</typeparam>
    public interface IUpdateExpressions<TEntity, TModel>
    {
        /// <summary>
        /// Условия отбора данных из репозитория сущности.
        /// </summary>
        /// <param name="request">Запрос.</param>
        public Expression<Func<TEntity, bool>> GetPredicate(TModel model);

        /// <summary>
        /// Возвращает выражение преобразования <see cref="TModel"/> в <see cref="TEntity"/>.
        /// </summary>
        /// <param name="model">Модель данных.</param>
        public Expression<Func<TEntity, TEntity>> GetSelector(TModel model);
    }
}
