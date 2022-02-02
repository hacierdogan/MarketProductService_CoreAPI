using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PPS.Business.Abstract;
using PPS.Business.Concrete;
using PPS.DataAccess.Abstract;
using PPS.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPS.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); //add controllers


            #region InterfaceList
            services.AddSingleton<ILanguageService, LanguageService>();
            services.AddSingleton<ILanguageRepository, LanguageRepository>();
            services.AddSingleton<IUnitService, UnitService>();
            services.AddSingleton<IUnitRepository, UnitRepository>();
            services.AddSingleton<IBrandService, BrandService>();
            services.AddSingleton<IBrandRepository, BrandRepository>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<ISourceService,SourceService> ();
            services.AddSingleton<ISourceRepository, SourceRepository>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IFileRepository, FileRepository>();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<ILogRepository, LogRepository>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<ITagService, TagService>();
            services.AddSingleton<ITagRepository, TagRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IUserRepository, UserRepository>();
            //services.AddSingleton<ISessionService, SessionService>();
            //services.AddSingleton<ISessionRepository, SessionRepository>();
            #endregion

            services.AddCors(c=>{
                c.AddPolicy("AllowHeader", options => options.AllowAnyHeader());
                c.AddPolicy("AllowMethod", options => options.AllowAnyMethod());
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                //c.AddPolicy("AllowCredentials", options => options.AllowCredentials());
            }); // for frontend connection
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            //.AllowCredentials()
            );
            
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //use controllers for route
            });

           

            
        }
    }
}
