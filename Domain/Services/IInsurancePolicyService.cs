using Common.Models;

namespace Domain.Services
{
    public interface IInsurancePolicyService : IBaseService<InsurancePolicyDTO>
    {
        InsurancePolicyDTO FindInsurancePolicyByCarLicensePlate(string carLicensePlate);

        InsurancePolicyDTO FindInsurancePolicyByPolicyNumber(string policyNumber);
    }
}
