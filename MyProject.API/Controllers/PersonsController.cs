using MyProject.API.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using MyProject.Business.Interfaces.Person;
using MyProject.Constraints;
using MyProject.Models.Common;
using MyProject.Models.Persons;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyProject.API.Controllers
{
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Produces("application/json")]
    [Route("MyProject/[controller]")]
    [Route("MyProject/[controller]/[action]")]
    [ErrorHandler]
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService person)
        {
            _personService = person;
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
        public async Task<IActionResult> Post([FromBody] Tb_PersonasFisicas obj, [FromHeader] int idUser)
        {
            var result = await _personService.InsertOne(obj);
            if (result.SystemCode == SystemCodes.Ok || result.SystemCode == SystemCodes.RecordCreateInternalError)
            {
                return Ok(result);
            }
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
        public async Task<IActionResult> Get([FromBody] Filter<Tb_PersonasFisicas> filter)
        {
            var result = await _personService.GetList(filter);

            if (result.SystemCode == SystemCodes.NoContent)
                return StatusCode((int)HttpStatusCode.NoContent, result);
            else
                return Ok(result);
        }

        
        /// <summary>
        /// Proceso para actualizar un registro.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPut]
        [ValidateModel]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromBody] Tb_PersonasFisicas obj, [FromHeader] int idUser)
        {
            var result = await _personService.UpdateOne(obj);

            if (result.SystemCode == SystemCodes.Ok)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }

        /// <summary>
        /// Proceso para eliminar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        //[HttpDelete("[action]/{id}")]
        [ValidateModel]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(int id, [FromHeader] int idUser)
        {
            var result = await _personService.DeleteOne(id);
            if (result.SystemCode == SystemCodes.Ok)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }

        [HttpGet("{id}")]
        //[HttpGet("[action]/{id}")]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(int id, [FromHeader] string idUser)
        {
            var result = await _personService.GetObjectWithRefs(id);
            if (result.SystemCode == SystemCodes.NoContent)
            {
                return StatusCode((int)HttpStatusCode.NoContent, result);
            }
            else
            {
                return Ok(result);
            }
        }

    }
}
