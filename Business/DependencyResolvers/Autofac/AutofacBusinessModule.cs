using Autofac;
using Autofac.Extras.DynamicProxy;
using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using CarRental.Data.Contracts.Repositories;
using CarRental.Data.Repositories;

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

            builder.RegisterType<BrandRepository>().As<IBrandRepository>().SingleInstance();
            builder.RegisterType<ColorRepository>().As<IColorRepository>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().SingleInstance();
            builder.RegisterType<RentalRepository>().As<IRentalRepository>().SingleInstance();
            builder.RegisterType<CarRepository>().As<ICarRepository>().SingleInstance();
            builder.RegisterType<CarImageRepository>().As<ICarImageRepository>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors(new ProxyGenerationOptions() { Selector = new AspectInterceptorSelector() })
                   .SingleInstance();
        }
    }
}