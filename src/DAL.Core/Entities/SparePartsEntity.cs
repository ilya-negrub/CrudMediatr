using DAL.Core.Interfaces;

namespace DAL.Core.Entities
{
    /// <summary>
    /// Запчасти.
    /// </summary>
    public class SparePartsEntity : IHaveId
    {
        /// <inheritdoc/>
        public long Id { get; set; }

        /// <summary>
        /// Наименование запчасти.
        /// </summary>
        public string Name { get; set; }
    }
}
