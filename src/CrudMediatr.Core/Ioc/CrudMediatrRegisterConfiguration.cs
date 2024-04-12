using CrudMediatr.Core.Expressions.Interfaces;
using CrudMediatr.Core.Interfaces;
using CrudMediatr.Core.Models;
using CrudMediatr.Core.Paginators;
using CrudMediatr.Core.RequestHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrudMediatr.Core.Ioc
{
    /// <summary>
    /// Конфигурация DI контейнера.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class CrudMediatrRegisterConfiguration<TEntity>
    {
        private readonly IServiceCollection _services;

        private Func<Type, Type, IServiceCollection> _registerFunc;

        public CrudMediatrRegisterConfiguration(IServiceCollection services)
        {
            _services = services;
            SetRegisterFunc(services.AddTransient);
        }

        /// <summary>
        /// Устанавливает функцию которая определяет жизненный цикл службы.
        /// </summary>
        /// <param name="func"></param>
        public void SetRegisterFunc(Func<Type, Type, IServiceCollection> func)
        {
            _registerFunc = func;
        }

        /// <summary>
        /// Регистрирует обработчик функции создания.
        /// </summary>
        /// <typeparam name="TModel">Тип параметров запроса.</typeparam>
        /// <typeparam name="TCreateExpressions">Тип службы выражений функции создания.</typeparam>
        public void RegisterCreateHandler<TModel, TCreateExpressions>()
            where TModel : IRequest
            where TCreateExpressions : class, ICreateExpressions<TEntity, TModel>
        {
            Register<
                ICreateExpressions<TEntity, TModel>,
                TCreateExpressions>();

            Register<
                IRequestHandler<TModel>,
                CreateRequestHandler<TEntity, TModel>>();
        }

        /// <summary>
        /// Регистрирует обработчик функции чтения.
        /// </summary>
        /// <typeparam name="TModel">Тип модели выходных данных.</typeparam>
        /// <typeparam name="TRequest">Тип параметров запроса.</typeparam>
        /// <typeparam name="TReadExpressions">Тип службы выражений функции чтения.</typeparam>
        public void RegisterReadHandler<TModel, TRequest, TReadExpressions>()
            where TRequest : IReadRequest<TModel>
            where TReadExpressions : class, IReadExpressions<TEntity, TModel, TRequest>
        {
            Register<
                IReadExpressions<TEntity, TModel, TRequest>,
                TReadExpressions>();

            Register<
                IQueryPaginator<TModel>,
                QueryPaginator<TModel>>();

            Register<
                IRequestHandler<TRequest, ReadResultModel<TModel>>,
                ReadRequestHandler<TEntity, TModel, TRequest>>();
        }

        /// <summary>
        /// Регистрирует обработчик функции обновления.
        /// </summary>
        /// <typeparam name="TModel">Тип параметров запроса.</typeparam>
        /// <typeparam name="TUpdateExpressions">Тип службы выражений функции обновления.</typeparam>
        public void RegisterUpdateHandler<TModel, TUpdateExpressions>()
            where TModel : IRequest
            where TUpdateExpressions : class, IUpdateExpressions<TEntity, TModel>
        {
            Register<
                IUpdateExpressions<TEntity, TModel>,
                TUpdateExpressions>();

            Register<
                IRequestHandler<TModel>,
                UpdateRequestHandler<TEntity, TModel>>();
        }

        /// <summary>
        /// Регистрирует обработчик функции удаления.
        /// </summary>
        /// <typeparam name="TModel">Тип параметров запроса.</typeparam>
        /// <typeparam name="TDeleteExpressions">Тип службы выражений функции удаления.</typeparam>
        public void RegisterDeleteHandler<TModel, TDeleteExpressions>()
            where TModel : IRequest
            where TDeleteExpressions : class, IDeleteExpressions<TEntity, TModel>
        {
            Register<
                IDeleteExpressions<TEntity, TModel>,
                TDeleteExpressions>();

            Register<
                IRequestHandler<TModel>,
                DeleteRequestHandler<TEntity, TModel>>();
        }


        private IServiceCollection Register<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            return _registerFunc(typeof(TService), typeof(TImplementation));
        }
    }
}
