using System.Linq.Expressions;

namespace CrudMediatr.Core.Expressions.Interfaces
{
    /// <summary>
    /// Реализует выражения Delete-операции.
    /// </summary>
    /// <typeparam name="TEntity">Сущность.</typeparam>
    /// <typeparam name="TModel">Модель данных.</typeparam>
    public interface IDeleteExpressions<TEntity, TModel>
    {
        /// <summary>
        /// Условия отбора данных из репозитория сущности.
        /// </summary>
        /// <param name="request">Запрос.</param>
        public Expression<Func<TEntity, bool>> GetPredicate(TModel request);
    }
}
