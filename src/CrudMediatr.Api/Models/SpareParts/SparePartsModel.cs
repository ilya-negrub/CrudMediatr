using DAL.Core.Interfaces;

namespace CrudMediatr.Api.Models.SpareParts
{
    /// <summary>
    /// Модель запчасти.
    /// </summary>
    public class SparePartsModel : IHaveId
    {
        /// <inheritdoc/>
        public long Id { get; set; }

        // <summary>
        /// Наименование запчасти.
        /// </summary>
        public string Name { get; set; }
    }
}
