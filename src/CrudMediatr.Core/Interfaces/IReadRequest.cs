using CrudMediatr.Core.Models;
using MediatR;

namespace CrudMediatr.Core.Interfaces
{
    /// <summary>
    /// Интерфейс маркера для представления запроса с ответом
    /// </summary>
    /// <typeparam name="TModel">Тип модели выходных данных.</typeparam>
    public interface IReadRequest<TModel> : IRequest<ReadResultModel<TModel>>, IPagingRequest
    {
    }
}
