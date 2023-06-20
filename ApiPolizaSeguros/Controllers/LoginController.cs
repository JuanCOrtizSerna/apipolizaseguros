using Common.Extensions;
using Common.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiPolizaSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        public ILoginService LoginService;

        public LoginController(ILoginService loginService) 
        {
            LoginService = loginService;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var token = this.LoginService.Authenticate(login);

            if(token == null)
            {
                return Json(ResponseExtension.AsResponseDTO<string>(null,
                   (int)HttpStatusCode.Unauthorized));
            }

            return Json(token.AsResponseDTO((int)HttpStatusCode.OK));
        }
    }
}
