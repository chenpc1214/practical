using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
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
            //自己加入的CROS設定
            services.AddCors(options =>                         
            {
                options.AddPolicy("AllowOrigin", setting =>
                {
                    setting.WithOrigins().AllowAnyHeader().AllowAnyMethod();
                });
            });

            //自己加入的預設序列化JSON物件
            services.AddControllersWithViews().AddNewtonsoftJson(options=>
                                                                  options.SerializerSettings.ReferenceLoopHandling =
                                                                   Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                                                                   .AddNewtonsoftJson(options=>options.SerializerSettings.ContractResolver=
                                                                   new DefaultContractResolver());   

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            //使用自己加入的CROS設定
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles(new StaticFileOptions
            {

                FileProvider = new PhysicalFileProvider(  Path.Combine(Directory.GetCurrentDirectory(),  "Photos" )  ),
                RequestPath = "/Photos"
                
            });
        }
    }
}
