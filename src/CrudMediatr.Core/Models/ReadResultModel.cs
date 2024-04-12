namespace CrudMediatr.Core.Models
{
    /// <summary>
    /// Модель результата операции чтения.
    /// </summary>
    /// <typeparam name="TModel">Тип модели выходных данных.</typeparam>
    public class ReadResultModel<TModel>
    {
        public ReadResultModel(
            IEnumerable<TModel> data,
            int totalCount,
            int pageCount)
        {
            Data = data;
            TotalCount = totalCount;
            PageCount = pageCount;
        }

        public IEnumerable<TModel> Data { get; init; }

        public int TotalCount { get; init; }

        public int PageCount { get; init; }
    }
}
