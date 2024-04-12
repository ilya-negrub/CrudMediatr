using System.Linq.Expressions;

namespace CrudMediatr.Core.Expressions.Interfaces
{
    /// <summary>
    /// Реализует выражения Creat-операции.
    /// </summary>
    /// <typeparam name="TEntity">Сущность.</typeparam>
    /// <typeparam name="TModel">Модель данных.</typeparam>
    public interface ICreateExpressions<TEntity, TModel>
    {
        /// <summary>
        /// Возвращает выражение преобразования <see cref="TModel"/> в <see cref="TEntity"/>.
        /// </summary>
        /// <param name="model">Модель данных.</param>
        public Expression<Func<TModel, TEntity>> GetSelector(TModel model);
    }
}
