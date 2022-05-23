using MyProject.API.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Business.Interfaces.User;
using MyProject.Constraints;
using MyProject.Models.Common;
using MyProject.Models.Users;
using System.Net;
using System.Threading.Tasks;

namespace MyProject.API.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Produces("application/json")]
    [Route("MyProject/[controller]")]
    [Route("MyProject/[controller]/[action]")]
    [ErrorHandler]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService service)
        {
            _userService = service;
        }

        /// <summary>
        /// Registrar Usuario
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] User obj, [FromHeader] string idUser)
        {
            var result = await _userService.InsertOne(obj);
            if (result.SystemCode == SystemCodes.Ok)
                return Ok(result);
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, result);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromBody] Filter<User> filter)
        {
            var result = await _userService.GetList(filter);

            if (result.SystemCode == SystemCodes.NoContent)
                return StatusCode((int)HttpStatusCode.NoContent, result);
            else
                return Ok(result);
        }
    }
}
