using MyProject.Common;
using MyProject.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Business.Interfaces.User
{
    public interface IUserService
    {
        
        //Task<HttpGenericResponse<List<Models.Users.User>>> GetListWithRefs(Filter<Models.Users.User> filter);
        Task<HttpGenericResponseNoData> InsertOne(Models.Users.User user);
        Task<HttpGenericResponse<List<Models.Users.User>>> GetList(Filter<Models.Users.User> filter);
        //Task<HttpGenericResponseNoData> UpdateOne(Models.Users.User user);
    }
}
