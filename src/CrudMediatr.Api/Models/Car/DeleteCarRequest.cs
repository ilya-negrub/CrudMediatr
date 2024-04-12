using MediatR;

namespace CrudMediatr.Api.Models.Car
{
    /// <summary>
    /// Модель запроса удаления записи.
    /// </summary>
    public class DeleteCarRequest : IRequest
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
    }
}
