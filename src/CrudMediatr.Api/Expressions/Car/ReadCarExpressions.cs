using CrudMediatr.Api.Models.Car;
using CrudMediatr.Api.Models.SpareParts;
using CrudMediatr.Core.Expressions.Interfaces;
using DAL.Core.Entities;
using System.Linq.Expressions;

namespace CrudMediatr.Api.Expressions.Car
{
    /// <summary>
    /// Реализует выражения Read-операции.
    /// </summary>
    public class ReadCarExpressions : IReadExpressions<CarEntity, CarModel, ReadCarRequest<CarModel>>
    {
        /// <inheritdoc/>
        public Expression<Func<CarEntity, bool>> GetPredicate(ReadCarRequest<CarModel> request)
        {
            return request.Id.HasValue
                ? x => x.Id == request.Id
                : x => true;
        }

        /// <inheritdoc/>
        public Expression<Func<CarEntity, CarModel>> GetSelector(ReadCarRequest<CarModel> request)
        {
            return x => new CarModel
            {
                Id = x.Id,
                Name = x.Name,
                SpareParts = x.SpareParts.Select(x => new SparePartsModel
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToArray(),
            };
        }
    }
}
