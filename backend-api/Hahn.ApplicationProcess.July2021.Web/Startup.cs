using FluentValidation;
using FluentValidation.AspNetCore;
using Hahn.ApplicationProcess.July2021.Data.DataContext;
using Hahn.ApplicationProcess.July2021.Domain.Models;
using Hahn.ApplicationProcess.July2021.Domain.Services;
using Hahn.ApplicationProcess.July2021.Domain.Validators;
using Hahn.ApplicationProcess.July2021.Web.MiddleWares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hahn.ApplicationProcess.July2021.Web
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
            services.AddDbContext<ApplicationProcessDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationProcessConnection")));

            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserAssetService, UserAssetService>();

            services.AddControllers(options =>
            {
                options.AllowEmptyInputInBodyModelBinding = true;
            }).AddFluentValidation();

            services.AddTransient<IValidator<UserBase>, UserValidator>();
            services.AddTransient<IValidator<AssetBase>, AssetValidator>();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            
            services.AddCors();

            // If using Kestrel:
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hahn.ApplicationProcess.July2021.Web", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicationProcess.July2021.Web v1"));
            }

            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseMiddleware<ExceptionMiddleware>();

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
