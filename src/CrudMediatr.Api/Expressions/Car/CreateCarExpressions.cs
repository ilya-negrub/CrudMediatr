using CrudMediatr.Api.Models.Car;
using CrudMediatr.Core.Expressions.Interfaces;
using DAL.Core.Entities;
using DAL.Core.Interfaces;
using System.Linq.Expressions;

namespace CrudMediatr.Api.Expressions.Car
{
    /// <summary>
    /// Реализует выражения Creat-операции.
    /// </summary>
    public class CreateCarExpressions : ICreateExpressions<CarEntity, CreateCarRequest>
    {
        private readonly IRepository<SparePartsEntity> _sparePartsRepository;

        public CreateCarExpressions(IRepository<SparePartsEntity> sparePartsRepository)
        {
            _sparePartsRepository = sparePartsRepository;
        }

        /// <inheritdoc/>
        public Expression<Func<CreateCarRequest, CarEntity>> GetSelector(CreateCarRequest model)
        {
            var sparePartsQuery = model.SparePartsIds != null
                ? _sparePartsRepository.GetQuery()
                    .Where(x => model.SparePartsIds.Contains(x.Id))
                : Array.Empty<SparePartsEntity>().AsQueryable();

            return x => new CarEntity
            {
                Id = x.Id,
                Name = x.Name,
                SpareParts = sparePartsQuery,
            };
        }
    }
}
