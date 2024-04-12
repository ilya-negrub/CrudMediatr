namespace DAL.Core.Interfaces
{
    public interface IFactory
    {
        public T Create<T>();
    }

    public class Factory : IFactory
    {
        private readonly IServiceProvider _provider;

        public Factory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Create<T>()
        {
            return (T)_provider.GetService(typeof(T));
        }
    }
}
