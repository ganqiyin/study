using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IoC.Web
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
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            ////¹ýÂËÆ÷×¢²á
            //builder.RegisterAssemblyTypes(Assembly.Load("IoC.Web"))
            //     .Where(t => t.BaseType.FullName.Contains("Filter"))
            //     .AsSelf();
            //

            //builder.RegisterAssemblyTypes(Assembly.Load("IoC.Application"), Assembly.Load("IoC.Domain"))
            //    .Where(x => x.BaseType.FullName.Contains("ScopedDenpency"))
            //    .AsSelf()
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope()
            //    .PropertiesAutowired();

            //builder.RegisterAssemblyTypes(Assembly.Load("IoC.Application"), Assembly.Load("IoC.Domain"))
            //  .Where(x => x.BaseType.FullName.Contains("SingletonDenpency"))
            //  .AsSelf()
            //  .AsImplementedInterfaces()
            //  .SingleInstance()
            //  .PropertiesAutowired();


            //builder.RegisterAssemblyTypes(Assembly.Load("IoC.Application"), Assembly.Load("IoC.Domain"))
            //  .Where(x => x.BaseType.FullName.Contains("TraintDenpency"))
            //  .AsSelf()
            //  .AsImplementedInterfaces()
            //  .InstancePerDependency()
            //  .PropertiesAutowired();

            builder.RegisterAssemblyTypes(Assembly.Load("IoC.Application"), Assembly.Load("IoC.Domain"))
              .AsSelf()
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope()
              .PropertiesAutowired();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
