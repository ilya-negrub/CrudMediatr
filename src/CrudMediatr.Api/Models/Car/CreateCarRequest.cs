using MediatR;

namespace CrudMediatr.Api.Models.Car
{
    /// <summary>
    /// Модель запроса создания записи.
    /// </summary>
    public class CreateCarRequest : IRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
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
