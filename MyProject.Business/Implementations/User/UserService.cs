using MongoDB.Driver;
using MyProject.Business.Interfaces.User;
using MyProject.Common;
using MyProject.Common.Utilities;
using MyProject.Data.Dapper.Implementations;
using MyProject.Models.Common;
using MyProject.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Business.Implementations.User
{
    public class UserService : IUserService
    {
        private const string collectionName = nameof(Models.Users);

        private readonly IMongoCollection<Models.Users.User> usersCollection;

        public UserService()
        {
            var client = new MongoClient(StaticConfig.MongoDBConnectionString);
            var database = client.GetDatabase(StaticConfig.MongoDBDatabaseName);
            usersCollection = database.GetCollection<Models.Users.User>(collectionName);

        }
        /// <summary>
        /// Servicio para Insertar un Usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<HttpGenericResponseNoData> InsertOne(Models.Users.User user)
        {
            // Limpiamos caracteres con trim
            user.Name = user.Name == null ? string.Empty : user.Name.Trim();
            user.LastName = user.LastName == null ? string.Empty : user.LastName.Trim();
            user.MotherLastName = user.MotherLastName == null ? string.Empty : user.MotherLastName.Trim();
            user.Phone = user.Phone == null ? string.Empty : user.Phone.Trim();
            user.UserName = user.UserName == null ? string.Empty : user.UserName.Trim();
            user.UserPassword = user.UserPassword == null ? string.Empty : user.UserPassword.Trim();
            user.CreationDate = DateTime.Now;
            user.UpdateDate = DateTime.Now;
            // Insertar objeto a mongo
            var result = await new DapperMongoManager<Models.Users.User>(collectionName).InsertOne(user);

            if (result.Code == Constraints.SystemCodes.Ok)
            {
                return new HttpGenericResponseNoData(result.Code, result.Code.ToString());

            }
            else
            {
                return new HttpGenericResponseNoData(result.Code, result.Exception.Message);
            }

        }


        public async Task<HttpGenericResponse<List<Models.Users.User>>> GetList(Filter<Models.Users.User> filter)
        {
            var result = new GenericResponse<List<Models.Users.User>>();

            var list = usersCollection.AsQueryable().Where(u => u.Status != 5).ToList()
               .Select(i => new Models.Users.User
               {
                   _id = i._id,
                   Name = i.Name,
                   LastName = i.LastName,
                   MotherLastName = i.MotherLastName,
                   UserName = i.UserName,
                   Email = i.Email,
                   Phone = i.Phone,
                   IdUserCreation = i.IdUserCreation,
                   IdUserUpdate = i.IdUserUpdate,
                   UpdateDate = i.UpdateDate,
                   CreationDate = i.CreationDate,
                   Status = i.Status,
               }).ToList();

            //var list = usersCollection.AsQueryable().Where(u => u.Status != 5).ToList();

            result.TotalRows = list.Count();
            result.Data = list;

            if (result.Data != null)
            {
                result.Code = SystemCodes.Ok;
                result.Message = SystemCodes.Ok.ToString();
            }
            else
            {
                result.Code = SystemCodes.NoContent;
                result.Data = new List<Models.Users.User>();
                result.Message = ConstantMessages.NoContentList;
            }

            return new HttpGenericResponse<List<Models.Users.User>> (result.Code,
                    result.Data,
                     result.Message,
                    result.TotalRows);
        }


    }
}
