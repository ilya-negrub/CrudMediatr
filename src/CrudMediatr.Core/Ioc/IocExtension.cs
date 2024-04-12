using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrudMediatr.Core.Ioc
{
    public static class IocExtension
    {
        /// <summary>
        /// Регистрируйте различные обработчики из сборок. 
        /// </summary>
        /// <param name="services">Определяет контракт для коллекции дескрипторов служб.</param>
        public static void RegisterCrudMediatr(
            this IServiceCollection services,
            Action<MediatRServiceConfiguration> action = null)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                action?.Invoke(cfg);
            });
        }

        /// <summary>
        /// Регистрирует CRUD операции для указанной сущности. 
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        /// <param name="services">Определяет контракт для коллекции дескрипторов служб.</param>
        /// <param name="configure">Делегат конфигурирования.</param>
        public static void RegisterCrudEntity<TEntity>(
            this IServiceCollection services,
            Action<CrudMediatrRegisterConfiguration<TEntity>> configure)
        {
            configure(new CrudMediatrRegisterConfiguration<TEntity>(services));
        }
    }
}
