using MyProject.API.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using MyProject.Business.Interfaces.Products;
using MyProject.Constraints;
using MyProject.Models.Common;
using System.Net;
using System.Threading.Tasks;
using MyProject.Models.Products;

namespace MyProject.API.Controllers
{

    [ApiController]
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Produces("application/json")]
    [Route("MyProject/[controller]")]
    [Route("MyProject/[controller]/[action]")]
    [ErrorHandler]
    public class ProductsController : Controller
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService service)
        {
            _productService = service;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(int idCategory)
        {
            var result = await _productService.GetList(idCategory);

            if (result.SystemCode == SystemCodes.NoContent)
                return StatusCode((int)HttpStatusCode.NoContent, result);
            else
                return Ok(result);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ADM_PRODUCTS obj, [FromHeader] int idUser)
        {
            var result = await _productService.InsertOne(obj);
            if (result.SystemCode == SystemCodes.Ok || result.SystemCode == SystemCodes.RecordCreateInternalError)
            {
                return Ok(result);
            }
            else
                return StatusCode((int)HttpStatusCode.InternalServerError, result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _productService.GetObjectWithRefs(id);
            if (result.SystemCode == SystemCodes.Ok || result.SystemCode == SystemCodes.NoContent)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }

        [HttpDelete("{id}")]
        [ValidateModel]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _productService.DeleteOne(id);
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
        /// Actualizar producto
        /// </summary>
        /// <param name="obj">Modeo de Producto</param>
        /// <param name="idUser">Id Usuario actualiza</param>
        /// <returns></returns>
        [HttpPut]
        [ValidateModel]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Common.HttpResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromBody] ADM_PRODUCTS obj)
        {
            var result = await _productService.UpdateOne(obj);

            if (result.SystemCode == SystemCodes.Ok)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, result);
            }
        }

    }
}
