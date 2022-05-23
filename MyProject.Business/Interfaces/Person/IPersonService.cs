using MyProject.Common;
using MyProject.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Business.Interfaces.Person
{
    public interface IPersonService
    {
        Task<HttpGenericResponseNoData> InsertOne(Models.Persons.Tb_PersonasFisicas person);

        Task<HttpGenericResponse<Models.Persons.Tb_PersonasFisicas>> GetObjectWithRefs(int id);

        Task<HttpGenericResponse<List<Models.Persons.Tb_PersonasFisicas>>> GetList(Filter<Models.Persons.Tb_PersonasFisicas> filter);

        Task<HttpGenericResponseNoData> UpdateOne(Models.Persons.Tb_PersonasFisicas obj);

        Task<HttpGenericResponseNoData> DeleteOne(int id);
    }
}
