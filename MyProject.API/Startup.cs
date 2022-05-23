using MyProject.Business.Interfaces.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyProject.Business.Implementations.Person;
using MyProject.Business.Implementations.Products;
using MyProject.Business.Implementations.Security;
using MyProject.Business.Implementations.User;
using MyProject.Business.Interfaces.Person;
using MyProject.Business.Interfaces.Products;
using MyProject.Business.Interfaces.User;
using MyProject.Common.Utilities;
using MyProject.Data.Dapper.Implementations;
using System;
using System.Text;

namespace MyProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region GeneralSettings

            StaticConfig.ExceptionMessage = "Excepción general, contacte con el administrador del sistema para más información";
            StaticConfig.WarningMessage = "Contacte con el administrador del sistema para más información";

            #endregion

            #region Security

            StaticConfig.JWTExpirationTime = int.Parse(configuration.GetSection("JwtSettings").GetValue<string>("ExpirationTime"));
            StaticConfig.JWTSecret = configuration.GetSection("JwtSettings").GetValue<string>("SecretKey");
            StaticConfig.EncryptionKey = configuration.GetSection("JwtSettings").GetValue<string>("EncriptionKey");

            #endregion


            #region MongoDB


            StaticConfig.MongoDBConnectionString = Environment.GetEnvironmentVariable("MyProject-WS-ConnectionString", EnvironmentVariableTarget.Machine) ?? configuration.GetSection("MongoDatabaseSettings").GetValue<string>("ConnectionString");
            StaticConfig.MongoDBDatabaseName = Environment.GetEnvironmentVariable("MyProject-WS-DataBaseName", EnvironmentVariableTarget.Machine) ?? configuration.GetSection("MongoDatabaseSettings").GetValue<string>("DatabaseName");

            #endregion

            #region SQL
            StaticConfig.SQLConnectionString = Environment.GetEnvironmentVariable("MyProject-SQL-ConnectionString", EnvironmentVariableTarget.Machine) ?? configuration.GetSection("ConnectionStrings").GetValue<string>("SystemConfiguration");

            #endregion


            #region Files

            StaticConfig.ImagesAbsolutePath = Environment.GetEnvironmentVariable("TMH_RAII", EnvironmentVariableTarget.Machine) ?? configuration.GetSection("FilesURLs").GetValue<string>("ImagesAbsolutePath");
            StaticConfig.UserAvatarURL = configuration.GetSection("FilesURLs").GetValue<string>("UserAvatarURL");

            #endregion

            #region Login

            StaticConfig.Version = configuration.GetSection("Logging").GetValue<string>("Version");

            #endregion

            #region LogsWindows

            //LogsWindows.LogsWindows Logs = new LogsWindows.LogsWindows(configuration.GetSection("Logging").GetValue<string>("LogsWindows"));

            #endregion

            #region FireBase

            #endregion
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region JWT
            services.AddCors();

            var key = Encoding.ASCII.GetBytes(StaticConfig.JWTSecret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            #endregion

            #region Swagger
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject v1", Version = "v1" });
            });
            #endregion

            #region IoC Configuration

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<IPersonService, PersonService>();
            #endregion


            services.AddControllers();
            services.AddMvc().AddNewtonsoftJson();
            services.AddLocalization(o => o.ResourcesPath = "Resources");

            #region MongoDB
            services.Configure<MongoDatabaseSettings>(Configuration.GetSection(nameof(MongoDatabaseSettings)));

            services.AddSingleton<Data.Dapper.Interfaces.IMongoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);
            #endregion

            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Swagger estara disponible solo en ambiente de desarrollo
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.ShowExtensions();
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyProject v1");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //IdentityModelEventSource.ShowPII = true; //To show detail of error and see the problem

        }
    }
}
