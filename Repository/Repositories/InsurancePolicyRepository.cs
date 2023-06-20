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
    }
}
