namespace DAL.Core.Interfaces
{
    /// <summary>
    /// Реализует объект имеющий идентификатор.
    /// </summary>
    public interface IHaveId
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }
    }
}
