using MyProject.Common.Utilities;
using MyProject.Constraints;
using MyProject.Models.Common;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Data.Dapper.Implementations
{
    /// <summary>
    /// Class in charge of the management of the database access and data retreiving
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //void Foo<T>() where T : BaseType
    public class DapperMongoManager<T> where T : class
    {
        private readonly IMongoCollection<T> Service;
        /// <summary>
        /// Class constructor, configures the connection
        /// </summary>   
        /// <param name="CollectionName">Mongodb collection name /param>
        public DapperMongoManager(string CollectionName)
        {
            var client = new MongoClient(StaticConfig.MongoDBConnectionString);
            var database = client.GetDatabase(StaticConfig.MongoDBDatabaseName);
            Service = database.GetCollection<T>(CollectionName);
        }

        #region Data Access Methods


        /// <summary>
        /// Inserta un nuevo documento.
        /// </summary>
        /// <param name="obj">Objeto a insertar</param>
        /// <returns></returns>
        public async Task<GenericResponse<T>> InsertOne(T obj)
        {
            var res = new GenericResponse<T>();
            try
            {
                await Service.InsertOneAsync(obj);
                res.Code = SystemCodes.Ok;
                res.Data = obj;
            }
            catch (Exception e)
            {
                res.Code = SystemCodes.DuplicityRecord;
                res.Message = e.Message;
                return res;
            }

            return res;
        }

        /// <summary>
        /// Actualiza un documento.
        /// </summary>
        /// <param name="obj">Objeto a actualizar</param>
        /// <param name="filter">Condiciones para actualizar</param>
        /// <returns></returns>
        public async Task<GenericResponse<T>> UpdateOne(T obj, System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            var res = new GenericResponse<T>();
            var obt = await Service.ReplaceOneAsync(filter, obj);

            if (obt.ModifiedCount > 0)
            {
                res.Code = SystemCodes.Ok;
                res.Message = SystemCodes.Ok.ToString();
                res.Data = obj;
            }
            else
            {
                res.Code = SystemCodes.NoContent;
                res.Message = ConstantMessages.ErrorUpdateMessage;
                res.Exception = new Exception(res.Code.ToString());
            }

            return res;
        }



        /// <summary>
        /// Eimina un documento.
        /// </summary>
        /// <param name="obj">Objeto a eliminar</param>
        /// <param name="filter">Condiciones para eliminar</param>
        /// <returns></returns>
        public async Task<GenericResponse<T>> DeleteOne(T obj, System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            var res = new GenericResponse<T>();

            var obt = await Service.DeleteOneAsync(filter);

            if (obt.DeletedCount > 0)
            {
                res.Code = SystemCodes.Ok;
                res.Message = SystemCodes.Ok.ToString();
                res.Data = obj;
            }
            else
            {
                res.Code = SystemCodes.NoContent;
                res.Message = ConstantMessages.ErrorDeleteMessage;
                res.Exception = new Exception(res.Code.ToString());
            }

            return res;
        }

        /// <summary>
        /// Obtiene un documento.
        /// </summary>
        /// <param name="filter">Condiciones para consultar documento</param>
        /// <returns></returns>
        public async Task<GenericResponse<T>> ExecObject(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            var res = new GenericResponse<T>();
            try
            {
                res.Data = await Service.Find(filter).FirstAsync();

                if (res.Data != null)
                {
                    res.Message = SystemCodes.Ok.ToString();
                    res.Code = SystemCodes.Ok;
                }
                else
                {
                    res.Code = SystemCodes.NoContent;
                    res.Message = ConstantMessages.NoContentObject;
                    res.Exception = new Exception(res.Code.ToString());
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToString() == ConstantMessages.SequenceNoElements)
                {
                    res.Code = SystemCodes.NoContent;
                    res.Message = ConstantMessages.NoContentObject;
                    res.Exception = ex;
                }
                else
                {
                    res.Code = SystemCodes.InternalError;
                    res.Message = ConstantMessages.GeneralError;
                    res.Exception = ex;
                }
            }

            return res;
        }

        /// <summary>
        /// Obtiene un listado de documentos.
        /// </summary>
        /// <param name="filter">Condiciones para consultar el listado de documentos</param>
        /// <returns></returns>
        public async Task<GenericResponse<List<T>>> ExecList(System.Linq.Expressions.Expression<Func<T, bool>> filter, int skip = 0, int limit = 0)
        {
            var res = new GenericResponse<List<T>>()
            {
                Data = new List<T>()
            };

            res.Data = await Service.Find(filter).Skip(skip).Limit(limit).ToListAsync();
            res.TotalRows = Convert.ToInt32(await Service.Find(filter).CountDocumentsAsync());

            if (res.Data.Count > 0)
            {
                res.Message = SystemCodes.Ok.ToString();
                res.Code = SystemCodes.Ok;
            }
            else
            {
                res.Code = SystemCodes.NoContent;
                res.Message = ConstantMessages.NoContentList;
                res.Exception = new Exception(res.Code.ToString());
            }

            return res;
        }


        /// <summary>
        /// Obtiene un listado de documentos.
        /// </summary>
        /// <param name="filter">Condiciones para consultar el listado de documentos</param>
        /// <returns></returns>
        public async Task<GenericResponse<List<T>>> ExecListProject(System.Linq.Expressions.Expression<Func<T, bool>> filter, ProjectionDefinition<T> fields)
        {
            var res = new GenericResponse<List<T>>()
            {
                Data = new List<T>()
            };


            res.Data = await Service.Find(filter).Project<T>(fields).ToListAsync();
            res.TotalRows = Convert.ToInt32(await Service.Find(filter).CountDocumentsAsync());

            if (res.Data.Count > 0)
            {
                res.Message = SystemCodes.Ok.ToString();
                res.Code = SystemCodes.Ok;
            }
            else
            {
                res.Code = SystemCodes.NoContent;
                res.Message = ConstantMessages.NoContentList;
                res.Exception = new Exception(res.Code.ToString());
            }

            return res;
        }

        #endregion
    }
}
