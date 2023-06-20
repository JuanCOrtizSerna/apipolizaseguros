using Common.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiPolizaSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePolicyController : BaseController<InsurancePolicyDTO>
    {
        protected IConfiguration _configuration;

        protected IInsurancePolicyService _InsurancePolicyService;

        protected IHttpContextAccessor _contextAccess;

        public InsurancePolicyController(
            IInsurancePolicyService InsurancePolicyService,
            IHttpContextAccessor contextAccess,
            IConfiguration configuration
            )
            : base(InsurancePolicyService)
        {
            _configuration = configuration;
            _contextAccess = contextAccess;
        }
    }
}