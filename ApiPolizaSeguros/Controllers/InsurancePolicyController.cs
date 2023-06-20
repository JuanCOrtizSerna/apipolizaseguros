using Common.Extensions;
using Common.Models;
using Common.Resources;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiPolizaSeguros.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePolicyController : BaseController<InsurancePolicyDTO>
    {
        protected IConfiguration _configuration;

        protected IInsurancePolicyService _insurancePolicyService;

        protected IHttpContextAccessor _contextAccess;

        public InsurancePolicyController(
            IInsurancePolicyService insurancePolicyService,
            IHttpContextAccessor contextAccess,
            IConfiguration configuration
            )
            : base(insurancePolicyService)
        {
            _configuration = configuration;
            _contextAccess = contextAccess;
            _insurancePolicyService = insurancePolicyService;
        }


        [HttpPost]
        [Route("FindInsurancePolicyByPolicyNumber")]
        public virtual async Task<IActionResult> FindInsurancePolicyByPolicyNumber([FromBody] RequestDTO policy)
        {
            var data = _insurancePolicyService.FindInsurancePolicyByPolicyNumber(policy.Id);

            if (data == null)
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.NotAcceptable, GlobalResource.ItemNotFoundMessage));

            return Json(data.AsResponseDTO((int)HttpStatusCode.OK));
        }

        [HttpPost]
        [Route("FindInsurancePolicyByCarLicensePlate")]
        public virtual async Task<IActionResult> FindInsurancePolicyByCarLicensePlate([FromBody] RequestDTO policy)
        {
            var data = _insurancePolicyService.FindInsurancePolicyByCarLicensePlate(policy.Id);

            if (data == null)
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                    (int)HttpStatusCode.NotAcceptable, GlobalResource.ItemNotFoundMessage));

            return Json(data.AsResponseDTO((int)HttpStatusCode.OK));
        }
    }
}