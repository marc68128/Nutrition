using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ninject;
using Ninject.Activation;
using Ninject.Infrastructure.Disposal;
using Nutrition.Api.Configuration;
using Nutrition.Api.ViewModels.Configuration;
using Nutrition.Core.Repositories.EntityFramework.Configuration;
using Nutrition.Core.Services.Configuration;
using System;
using System.Threading;

namespace Nutrition.Api
{
    public class Startup
    {
        private readonly AsyncLocal<Scope> scopeProvider = new AsyncLocal<Scope>();
        private IKernel Kernel { get; set; }

        private object Resolve(Type type)
        {
            return Kernel.Get(type);
        }

        private object RequestScope(IContext context)
        {
            return scopeProvider.Value;
        }

        private sealed class Scope : DisposableObject { }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddRequestScopingMiddleware(() => scopeProvider.Value = new Scope());
            services.AddCustomControllerActivation(Resolve);
            services.AddCustomViewComponentActivation(Resolve);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.Kernel = this.RegisterApplicationComponents(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAnyOrigin");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }

        private IKernel RegisterApplicationComponents(IApplicationBuilder app)
        {
            // IKernelConfiguration config = new KernelConfiguration();
            var kernel = new StandardKernel();

            // Register application services
            foreach (var ctrlType in app.GetControllerTypes())
            {
                kernel.Bind(ctrlType).ToSelf().InScope(RequestScope);
            }

            var connectionString = Configuration.GetValue<string>("ConnectionStrings:NutContext");

            kernel.Load(new RepositoryModule(connectionString));
            kernel.Load(new ServiceModule());

            var createLoggerMethod = typeof(LoggerFactoryExtensions).GetMethod(nameof(LoggerFactoryExtensions.CreateLogger), new[] { typeof(ILoggerFactory) });
            kernel.Bind(typeof(ILogger<>)).ToMethod(context =>
            {
                var createLoggerGeneric = createLoggerMethod.MakeGenericMethod(context.GenericArguments);
                var logger = createLoggerGeneric.Invoke(null, new[] { new LoggerFactory() });
                return logger;
            });

            kernel.Bind<IMapper>().ToConstant(new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServicesMappingProfile>();
                cfg.AddProfile<ViewModelsMappingProfile>();
            })));


            // Cross-wire required framework services
            kernel.BindToMethod(app.GetRequestService<IViewBufferScope>);

            return kernel;
        }
    }
}
