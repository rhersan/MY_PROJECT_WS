using MyProject.Common;
using MyProject.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Business.Interfaces.Products
{
    public interface IProductsService
    {
        Task<HttpGenericResponseNoData> InsertOne(Models.Products.ADM_PRODUCTS person);

        Task<HttpGenericResponse<Models.Products.ADM_PRODUCTS>> GetObjectWithRefs(string id);

        Task<HttpGenericResponse<List<Models.Products.ADM_PRODUCTS>>> GetList(int idCategory);

        Task<HttpGenericResponseNoData> UpdateOne(Models.Products.ADM_PRODUCTS obj);

        Task<HttpGenericResponseNoData> DeleteOne(string id);
    }
}
