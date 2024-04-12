using CrudMediatr.Core.Interfaces;

namespace CrudMediatr.Api.Models.Car
{
    /// <summary>
    /// Модель запроса.
    /// </summary>
    /// <typeparam name="TModel">Тип ответа.</typeparam>
    public class ReadCarRequest<TModel> : IReadRequest<TModel>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long? Id { get; set; }

        /// <inheritdoc/>
        public int PageIndex { get; set; } = 0;

        /// <inheritdoc/>
        public int PageSize { get; set; } = 5;
    }
}
