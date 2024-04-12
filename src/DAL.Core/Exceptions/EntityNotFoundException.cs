namespace DAL.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("Сущность не найдена.")
        {

        }
    }
}
