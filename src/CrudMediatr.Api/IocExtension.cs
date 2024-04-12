using CrudMediatr.Api.Expressions.Car;
using CrudMediatr.Api.Models.Car;
using CrudMediatr.Core.Ioc;
using DAL.Core.Entities;
using DAL.Core.Interfaces;
using DAL.Core.Services;

namespace CrudMediatr.Api
{
    public static class IocExtension
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<IFactory, Factory>();
            services.AddSingleton(typeof(IRepository<>), typeof(LocalRepository<>));
            services.AddTransient<IMockupLocalRepository<CarEntity>, MockupCarLocalRepository>();
            services.AddTransient<IMockupLocalRepository<SparePartsEntity>, MockupSparePartsLocalRepository>();

            services.RegisterCrudMediatr();

            services.RegisterCrudEntity<CarEntity>(cfg =>
            {
                cfg.RegisterCreateHandler<CreateCarRequest, CreateCarExpressions>();
                cfg.RegisterReadHandler<CarModel, ReadCarRequest<CarModel>, ReadCarExpressions>();
                cfg.RegisterUpdateHandler<UpdateCarRequest, UpdateCarExpressions>();
                cfg.RegisterDeleteHandler<DeleteCarRequest, DeleteCarExpressions>();
            });
        }
    }
}
