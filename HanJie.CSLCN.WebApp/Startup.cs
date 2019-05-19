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
        /// AppSettings.json �ļ���ǿ���Ͷ��󣬸ö�������ڶ�ȡ�����ļ����趨��ֵ��
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

            //�����ݿ������Ķ������DI����
            services.AddDbContext<CSLDbContext>
                (options => options.UseMySql(AppSettings.ConnectionString));  //b => b.MigrationsAssembly("HanJie.CSLCN.WebApp"))

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
        /// �� Startup ���캯�������ȫ����Ҫ�ĳ�ʼ��������
        /// </summary>
        private void Globalinitialize()
        {
            //�� AppSettings.json �����ļ��е�ֵ�󶨵�ǿ����ģ��
            AppSettings = this.Configuration.GetSection("AppSettings").Get<AppSettings>();

        }
    }
}
