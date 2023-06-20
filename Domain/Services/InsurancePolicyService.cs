using AutoMapper;
using Common.Models;
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
            IInsurancePolicyRepository InsurancePolicyRepository
            )
            : base(repository, mapper, configuration)
        {
            InsurancePolicyRepository = InsurancePolicyRepository;
        }
    }
}
