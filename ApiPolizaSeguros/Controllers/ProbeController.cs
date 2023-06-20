using Microsoft.AspNetCore.Mvc;

namespace App.web.Controllers
{
    [Route("/")]
    [ApiController]
    public class ProbeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "ApiPolizaSeguros";
        }
    }
}
