using CrudMediatr.Api.Models.Car;
using CrudMediatr.Core.Expressions.Interfaces;
using DAL.Core.Entities;
using DAL.Core.Interfaces;
using System.Linq.Expressions;

namespace CrudMediatr.Api.Expressions.Car
{
    /// <summary>
    /// Реализует выражения Update-операции.
    /// </summary>
    public class UpdateCarExpressions : IUpdateExpressions<CarEntity, UpdateCarRequest>
    {
        private readonly IRepository<SparePartsEntity> _sparePartsRepository;

        public UpdateCarExpressions(IRepository<SparePartsEntity> sparePartsRepository)
        {
            _sparePartsRepository = sparePartsRepository;
        }

        /// <inheritdoc/>
        public Expression<Func<CarEntity, bool>> GetPredicate(UpdateCarRequest model)
        {
            return x => x.Id == model.Id;
        }

        /// <inheritdoc/>
        public Expression<Func<CarEntity, CarEntity>> GetSelector(UpdateCarRequest model)
        {
            var sparePartsQuery = _sparePartsRepository.GetQuery()
                .Where(x => model.SparePartsIds.Contains(x.Id));

            return oldValue => new CarEntity
            {
                Id = oldValue.Id,
                Name = !string.IsNullOrEmpty(model.Name)
                    ? model.Name
                    : oldValue.Name,
                SpareParts = model.SparePartsIds != null
                    ? sparePartsQuery
                    : oldValue.SpareParts,
            };
        }
    }
}
