using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TicTacToe.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new BaseModule());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
    }

    public class BaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MyClass>().As<IMyClass>();
        }
    }

    public class MyClass : IMyClass
    {
    }

    public interface IMyClass
    {
    }
}
