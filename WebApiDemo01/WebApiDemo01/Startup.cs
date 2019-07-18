using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiDemo01.Model;

namespace WebApiDemo01
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder.WithOrigins("http://localhost:58318")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            // For CORS.
            //services.AddCors(options =>
            //{
            //    options.AddPolicy(MyAllowSpecificOrigins,
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:58318/")
            //                .AllowAnyHeader()
            //                .AllowAnyMethod();
            //        });
            //});

            //// Multiple policies. Apply to Controller or Action with:
            //// [EnableCors("AnotherPolicy")] or [EnableCors] (for default).
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(
            //        builder =>
            //        {
            //            builder.WithOrigins("http://localhost:58318",
            //                               "http://localhost");
            //        });
            //    options.AddPolicy("AnotherPolicy",
            //        builder =>
            //        {
            //            builder.WithOrigins("http://www.somesite.com")
            //                .AllowAnyHeader()
            //                .AllowAnyMethod();
            //        });
            //});

            // For XML return from API.
            services.AddMvc()
                .AddXmlSerializerFormatters();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // For CORS.
            app.UseCors("CorsPolicy");

            //app.UseCors(MyAllowSpecificOrigins);
            // Shows UseCors with CorsPolicyBuilder.
            //app.UseCors(builder =>
            //{
            //    //builder.WithOrigins("http://localhost:58318");
            //    builder.AllowAnyOrigin();
            //});

            // Add these 2 lines for jQuery calls to API.
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //

            app.UseMvc();
        }
    }
}
