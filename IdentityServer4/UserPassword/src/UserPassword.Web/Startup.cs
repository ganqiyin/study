using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UserPassword.Web
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
            services.AddControllersWithViews();
            //
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options => {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            //����ִ��OpenID ConnectЭ��Ĵ������
            .AddOpenIdConnect("oidc",options=> {
                options.Authority = "https://localhost:5001";//�������Ʒ�������
                options.ClientId = "mvc";
                options.ClientSecret = "secret";
                options.ResponseType = "code";
                options.SaveTokens = true;//���ڽ�����IdentityServer�����Ʊ�����cookie��

                //options.Scope.Add("profile");
                //options.GetClaimsFromUserInfoEndpoint = true;
                //options.Scope.Clear();
                //options.Scope.Add("openid");
                //options.Scope.Add("profile");
            });
            //
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //
           // app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .RequireAuthorization();//��������Ӧ�ó������������
            });
        }
    }
}
