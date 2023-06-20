using AutoMapper;
using Config.Dependencies;
using Domain.Services;
using FakeItEasy;
using Mongo2Go;
using MongoDB.Driver;
using Repository.Database;
using Repository.Entities;
using Repository.Repositories;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace ApiPolizaSeguros.Tests.Fixtures
{
    public class InsurancePolicyFixture
    {
        public MongoDbRunner Runner;

        public DbContext Context;

        public InsurancePolicyService CreateStandardFixture()
        {
            IConfiguration configuration  = A.Fake<IConfiguration>();
            Context = CreateContext();
            IBaseCRUDRepository<InsurancePolicy> baseRepository = new InsurancePolicyRepository(Context);
            InsurancePolicyRepository repository = new InsurancePolicyRepository(Context);
            IMapper mapper = CreateMapper();

            InsurancePolicyService service = new InsurancePolicyService(
                baseRepository,
                mapper,
                configuration,
                repository
                );

            return service;
        }

        private DbContext CreateContext()
        {
            Runner = MongoDbRunner.Start();

            IMongoClient client = new MongoClient(Runner.ConnectionString);
            IMongoDatabase database = client.GetDatabase("IntegrationTest");

            return new DbContext(database, client);
        }

        public static IMapper CreateMapper()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration((config) =>
            {
                config.AddProfile(new AutoMapperProfile());
            });
            IMapper mapper = mapperConfiguration.CreateMapper();
            return mapper;
        }
    }
}
