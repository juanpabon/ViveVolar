using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViveVolar.Abstractions;
using ViveVolar.Application;
using ViveVolar.DataAccess;
using ViveVolar.Repository;
using ViveVolar.Services;
using ViveVolar.Domain.Services;
using ViveVolar.Entities;

namespace ViveVolar.WebApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ViveVolar.WebApi", Version = "v1" });
            });
            services.AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("ViveVolar.WebApi")));
            
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwt =>
                {
                    var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);
                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true,
                    };
                });
            
            services.AddScoped(typeof(IVueloService), typeof(VueloService));
            services.AddScoped(typeof(IValidarVuelo), typeof(VueloApplication));
            services.AddScoped(typeof(IVueloApplication), typeof(VueloApplication));
            services.AddScoped(typeof(IVueloRepository), typeof(VueloRepository));
            services.AddScoped(typeof(IVueloDbContext), typeof(VueloDBContext));

            services.AddScoped(typeof(IReservaService), typeof(ReservaService));
            services.AddScoped(typeof(IReservaApplication), typeof(ReservaApplication));
            services.AddScoped(typeof(IReservaRepository), typeof(ReservaRepository));
            services.AddScoped(typeof(IReservaDBContext), typeof(ReservaDBContext));

            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(IUserApplication), typeof(UserApplication));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IUserDbContext), typeof(UserDbContext));

            services.AddScoped(typeof(ISendEmail), typeof(SendEmail));
            services.AddScoped(typeof(IValidaciones), typeof(Validaciones));
            services.AddScoped(typeof(ITokenHandlerService), typeof(TokenHandlerService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ApiDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ViveVolar.WebApi v1"));
            }

            //app.UseHttpsRedirection();
            db.Database.Migrate();
            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
