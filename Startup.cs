using BlazorStrap;
using DoAn1.Areas.Identity;
using DoAn1.Data;
using DoAn1.Models;
using DoAn1.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DoAn1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddSingleton<WeatherForecastService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<ProductService>();
            services.AddScoped<CartService>();
            services.AddScoped<SubHeaderService>();
            services.AddScoped<PaymentService>();
            services.AddScoped<OrderService>();
            //services.AddAuthentication().AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
            //    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            //});
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
 .AddCookie()
 .AddOpenIdConnect("Auth0", options =>
 {
     options.Authority = $"https://{Configuration["Auth0:Domain"]}";

     options.ClientId = Configuration["Auth0:ClientId"];
     options.ClientSecret = Configuration["Auth0:ClientSecret"];

     options.ResponseType = OpenIdConnectResponseType.Code;

     options.Scope.Clear();
     options.Scope.Add("openid");
     options.Scope.Add("profile"); // <- Optional extra
     options.Scope.Add("email");   // <- Optional extra



     options.CallbackPath = new PathString("/callback");
     options.ClaimsIssuer = "Auth0";
     options.SaveTokens = true;
     options.TokenValidationParameters = new TokenValidationParameters
     {
         NameClaimType = "name"
     };



     // Add handling of lo
     options.Events = new OpenIdConnectEvents
     {
         OnRedirectToIdentityProviderForSignOut = (context) =>
         {
             var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

             var postLogoutUri = context.Properties.RedirectUri;
             if (!string.IsNullOrEmpty(postLogoutUri))
             {
                 if (postLogoutUri.StartsWith("/"))
                 {
                     var request = context.Request;
                     postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                 }
                 logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
             }

             context.Response.Redirect(logoutUri);
             context.HandleResponse();

             return Task.CompletedTask;
         }
     };
 });

            services.AddBlazorStrap();


            //services.AddAuth0WebAppAuthentication(options => {
            //    options.Domain = Configuration["Auth0:Domain"];
            //    options.ClientId = Configuration["Auth0:ClientId"];
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete("Obsolete")]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });


            app.Use(next => context =>
            {
                if (string.Equals(context.Request.Headers["X-Forwarded-Proto"], "https", StringComparison.OrdinalIgnoreCase))
                {
                    context.Request.Scheme = "https";
                }

                return next(context);
            });

        }
    }
}
