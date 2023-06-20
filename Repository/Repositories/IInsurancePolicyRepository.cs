using Repository.Entities;

namespace Repository.Repositories
{
    public interface IInsurancePolicyRepository : IBaseCRUDRepository<InsurancePolicy>
    {
        InsurancePolicy FindInsurancePolicyByCarLicensePlate(string carLicensePlate);

        InsurancePolicy FindInsurancePolicyByPolicyNumber(string policyNumber);
    }
}
