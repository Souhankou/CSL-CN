using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HanJie.CSLCN.Models;
using Microsoft.EntityFrameworkCore;
using HanJie.CSLCN.Datas;
using HanJie.CSLCN.Models.Common;
using HanJie.CSLCN.Models.DataModels;
using System;
using System.Linq;

namespace HanJie.CSLCN.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Globalinitialize();
        }

        /// <summary>
        /// AppSettings.json 文件的强类型对象，该对象可用于读取配置文件中设定的值。
        /// </summary>
        public static AppSettings AppSettings { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //将数据库上下文对象加入DI容器
            services.AddDbContext<CSLDbContext>
                (options => options.UseMySql(AppSettings.ConnectionString));  //b => b.MigrationsAssembly("HanJie.CSLCN.WebApp"))


            CSLDbContext dbContext = new CSLDbContext();
            dbContext.WikiPassages.Add(new WikiPassage() { Title = "Title", Content = "Content", CreateDate = DateTime.Now, LastModifyDate = DateTime.Now });
            dbContext.SaveChanges();

            WikiPassage passasge = dbContext.WikiPassages.Where(p => p.Title == "Title").FirstOrDefault();
            throw new NotImplementedException();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        /// <summary>
        /// 在 Startup 构造函数中完成全局重要的初始化操作。
        /// </summary>
        private void Globalinitialize()
        {
            //将 AppSettings.json 配置文件中的值绑定到强类型模型
            AppSettings = this.Configuration.GetSection("AppSettings").Get<AppSettings>();

        }
    }
}
