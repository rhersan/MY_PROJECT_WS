using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.API.ActionFilters;
using MyProject.Business.Interfaces.Security;
using MyProject.Common;
using MyProject.Common.Utilities;
using MyProject.Constraints;
using MyProject.Models.Common;
using MyProject.Models.Login;
using System.Net;
using System.Threading.Tasks;

namespace MyProject.API.Controllers
{
    [ApiController]
    [Route("MyProject")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ErrorHandler]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _service;

        public LoginController(IAuthService service)
        {
            _service = service;
        }

        [HttpGet("Login")]
        [ValidateModel]
        [AllowAnonymous]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get()
        {
            Login login = new Login();

            login.username = Request.Headers["Username"];
            login.password = Request.Headers["Password"];

            if (string.IsNullOrEmpty(login.username) || string.IsNullOrEmpty(login.password))
            {
                var gr = new GenericResponse<object>();
                gr.Code = SystemCodes.InvalidHeaders;
                gr.Message = SystemCodes.InvalidHeaders.ToString();

                var resultOption1 = new LoginResponse<object>(
                    gr.Code,
                    gr.Data,
                    gr.Code.ToString(),
                    gr.TotalRows
                    );
                return StatusCode((int)HttpStatusCode.BadRequest, resultOption1);
            }

            var result = await _service.Login(login);
            if (result.SystemCode == SystemCodes.SuccessfulLogin)
            {
                result.Version = StaticConfig.Version;
                return Ok(result);
            }
            else
            {
                result.Version = StaticConfig.Version;
                return StatusCode((int)HttpStatusCode.Unauthorized, result);
            }
        }

    }
}
