using DAL.Core.Interfaces;

namespace DAL.Core.Entities
{
    /// <summary>
    /// Сущность автомобиль.
    /// </summary>
    public class CarEntity : IHaveId
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <inheritdoc cref="SparePartsEntity"/>.
        public IQueryable<SparePartsEntity> SpareParts { get; set; }
    }
}
