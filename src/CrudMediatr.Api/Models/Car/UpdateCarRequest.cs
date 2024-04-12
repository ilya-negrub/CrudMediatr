using MediatR;

namespace CrudMediatr.Api.Models.Car
{
    /// <summary>
    /// Модель запроса обновления записи.
    /// </summary>
    public class UpdateCarRequest : IRequest
    {
        /// <inheritdoc/>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Запчасти.
        /// </summary>
        public long[] SparePartsIds { get; set; }
    }
}
