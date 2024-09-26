using Autofac;
using Autofac.Extras.DynamicProxy;
using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using CarRental.Data.Abstract;
using CarRental.Data.Concrete.EntityFramework;

namespace CarRental.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrandService>().As<IBrandService>().SingleInstance();
            builder.RegisterType<ColorService>().As<IColorService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<CustomerService>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<RentalService>().As<IRentalService>().SingleInstance();
            builder.RegisterType<CarService>().As<ICarService>().SingleInstance();
            builder.RegisterType<CarImageService>().As<ICarImageService>().SingleInstance();

            builder.RegisterType<EfBrandRepository>().As<IBrandRepository>().SingleInstance();
            builder.RegisterType<EfColorRepository>().As<IColorRepository>().SingleInstance();
            builder.RegisterType<EfUserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<EfCustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<EfRentalRepository>().As<IRentalRepository>().SingleInstance();
            builder.RegisterType<EfCarRepository>().As<ICarRepository>().SingleInstance();
            builder.RegisterType<EfCarImageRepository>().As<ICarImageRepository>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors(new ProxyGenerationOptions() { Selector = new AspectInterceptorSelector() })
                   .SingleInstance();
        }
    }
}