using Common.Models;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPolizaSeguros.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserDTO>
    {
        protected IConfiguration _configuration;

        protected IUserService _userService;

        protected IHttpContextAccessor _contextAccess;

        public UserController(
            IUserService userService,
            IHttpContextAccessor contextAccess,
            IConfiguration configuration
            )
            : base(userService)
        {
            _configuration = configuration;
            _contextAccess = contextAccess;
        }
    }
}