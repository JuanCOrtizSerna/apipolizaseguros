using AutoMapper;
using Common.Models;
using Common.Resources;
using Microsoft.Extensions.Configuration;
using Repository.Entities;
using Repository.Repositories;

namespace Domain.Services
{
    public class InsurancePolicyService : BaseService<InsurancePolicyDTO, InsurancePolicy>, IInsurancePolicyService
    {
        IInsurancePolicyRepository InsurancePolicyRepository;

        public InsurancePolicyService(
            IBaseCRUDRepository<InsurancePolicy> repository,
            IMapper mapper,
            IConfiguration configuration,
            IInsurancePolicyRepository insurancePolicyRepository
            )
            : base(repository, mapper, configuration)
        {
            InsurancePolicyRepository = insurancePolicyRepository;
        }

        public override InsurancePolicyDTO Create(InsurancePolicyDTO dto, bool autoSave = true)
        {
            dto.PolicyNumber = Guid.NewGuid().ToString();

            ValidateInsurancePolicy(dto);

            return base.Create(dto, autoSave);
        }

        public InsurancePolicyDTO FindInsurancePolicyByCarLicensePlate(string carLicensePlate)
        {
            return _mapperDependency.Map<InsurancePolicyDTO>(InsurancePolicyRepository.FindInsurancePolicyByCarLicensePlate(carLicensePlate));
        }

        public InsurancePolicyDTO FindInsurancePolicyByPolicyNumber(string policyNumber)
        {
            return _mapperDependency.Map<InsurancePolicyDTO>(InsurancePolicyRepository.FindInsurancePolicyByPolicyNumber(policyNumber));
        }

        public void ValidateInsurancePolicy(InsurancePolicyDTO dto)
        {
            if (dto.PolicyExpirationDate <= DateTime.Now)
            {
                throw new Exception(GlobalResource.InvalidPolicy);
            }
        }
    }
}
