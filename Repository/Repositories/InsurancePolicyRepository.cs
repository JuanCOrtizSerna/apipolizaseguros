using MongoDB.Driver;
using Repository.Database;
using Repository.Entities;

namespace Repository.Repositories
{
    public class InsurancePolicyRepository : BaseCRUDMongoRepository<InsurancePolicy>, IInsurancePolicyRepository
    {
        public DbContext Context
        {
            get
            {
                return (DbContext)_Database;
            }
        }

        public InsurancePolicyRepository(IMongoDbContext dbContext)
            : base(dbContext)
        {
        }

        public InsurancePolicy FindInsurancePolicyByCarLicensePlate(string carLicensePlate)
        {
            var filter = Builders<InsurancePolicy>.Filter.Eq("CarLicensePlate", carLicensePlate);

            var insurancePolicy = _Table.Find(filter).FirstOrDefault();

            return insurancePolicy;
        }

        public InsurancePolicy FindInsurancePolicyByPolicyNumber(string policyNumber)
        {
            var filter = Builders<InsurancePolicy>.Filter.Eq("PolicyNumber", policyNumber);

            var insurancePolicy = _Table.Find(filter).FirstOrDefault();

            return insurancePolicy;
        }
    }
}
