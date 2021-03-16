using BLL.Abstract;
using BLL.Concrete;
using DAL.Abstract;
using DAL.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<IUserService, UserManager>();
            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<IRentalService, RentalManager>();
            //services.AddSingleton<ICarService, CarManager>();

            //services.AddSingleton<IBrandDal, EfBrandDal>();
            //services.AddSingleton<IColorDal, EfColorDal>();
            //services.AddSingleton<IUserDal, EfUserDal>();
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();
            //services.AddSingleton<IRentalDal, EfRentalDal>();
            //services.AddSingleton<ICarDal, EfCarDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
