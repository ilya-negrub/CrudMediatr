using CrudMediatr.Api.Models.Car;
using CrudMediatr.Core.Expressions.Interfaces;
using DAL.Core.Entities;
using System.Linq.Expressions;

namespace CrudMediatr.Api.Expressions.Car
{
    /// <summary>
    /// Реализует выражения Delete-операции.
    /// </summary>
    public class DeleteCarExpressions : IDeleteExpressions<CarEntity, DeleteCarRequest>
    {
        /// <inheritdoc/>
        public Expression<Func<CarEntity, bool>> GetPredicate(DeleteCarRequest request)
        {
            return x => x.Id == request.Id;
        }
    }
}
