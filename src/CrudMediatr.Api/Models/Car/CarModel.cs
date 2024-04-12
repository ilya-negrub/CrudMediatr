using CrudMediatr.Api.Models.SpareParts;
using DAL.Core.Interfaces;

namespace CrudMediatr.Api.Models.Car
{
    /// <summary>
    /// Модель данных сущности.
    /// </summary>
    public class CarModel : IHaveId
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
        public SparePartsModel[] SpareParts { get; set; }
    }
}
