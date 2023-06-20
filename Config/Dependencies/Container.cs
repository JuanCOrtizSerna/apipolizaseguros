using AutoMapper;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Repository.Database;
using Repository.Entities;
using Repository.Repositories;

namespace Config.Dependencies
{
    public class Container
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {

            #region Mapper

            services.AddAutoMapper(typeof(Container));

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = configMapper.CreateMapper();

            services.AddSingleton(mapper);

            #endregion

            #region Conexion Base de datos

            services.Configure<MongoSettings>(options => {
                options.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
                options.Database = configuration.GetSection("MongoConnection:Database").Value;
                options.ConnectTimeout = int.Parse(configuration.GetSection("MongoConnection:ConnectTimeout").Value ?? "120");
                options.SocketTimeout = int.Parse(configuration.GetSection("MongoConnection:SocketTimeout").Value ?? "120");
                options.MaxConnectionIdleTime = int.Parse(configuration.GetSection("MongoConnection:MaxConnectionIdleTime").Value ?? "60");
            });

            services.AddScoped<IMongoDbContext, DbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            var mongoClient = new MongoClient(configuration.GetSection("MongoConnection:ConnectionString").Value);
            services.AddSingleton<IMongoClient>(mongoClient);

            #endregion


            #region services and repositories

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInsurancePolicyService, InsurancePolicyService>();
            services.AddScoped<IBaseCRUDRepository<InsurancePolicy>, InsurancePolicyRepository>();
            services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();
            services.AddScoped<IBaseCRUDRepository<User>, UserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginService, LoginService>();

            #endregion

            #region Others
            services.AddSingleton<IConfiguration>(configuration);
            #endregion

		}
    }
}
