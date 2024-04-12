namespace CrudMediatr.Core.Interfaces
{
    /// <summary>
    /// Интерфейс маркера для разделения на страницы.
    /// </summary>
    public interface IPagingRequest
    {
        /// <summary>
        /// Индекс начала страницы.
        /// </summary>
        /// <remarks>Начинается с 0.</remarks>
        public int PageIndex { get; set; }

        /// <summary>
        /// Размер страницы.
        /// </summary>
        /// <remarks>
        /// Если указать значение 0, будет возвращен полный список.
        /// </remarks>
        public int PageSize { get; set; }
    }
}
