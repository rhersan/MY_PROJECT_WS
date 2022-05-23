using MyProject.Business.Interfaces.Common;
using MyProject.Common;
using MyProject.Constraints;
using MyProject.Data.Dapper.Implementations;
using MyProject.Models.Logs;
using System;
using System.Threading.Tasks;

namespace MyProject.Business.Implementations.Common
{
    public class LogService : ILogService
    {

        private const string collectionName = nameof(MyProject.Models.Logs);

        /// <summary>
        /// Constructor
        /// </summary>
        public LogService()
        {

        }

        /// <summary>
        /// Actualiza un log.
        /// </summary>   
        /// <param name="log">Objeto con datos del log a actualizar.</param>
        public async Task<HttpGenericResponseNoData> Update(Log obj)
        {

            System.Linq.Expressions.Expression<Func<Log, bool>> _filter = a => true;

            if (obj._id.Length == 24)
            {
                _filter = _filter = a => a._id == obj._id;
            }

            var result = await new DapperMongoManager<Log>(collectionName).UpdateOne(obj, _filter);

            if (result.Code == SystemCodes.Ok)
            {
                if (result.Data != null)
                {
                    return new HttpGenericResponseNoData(result.Code, result.Code.ToString());
                }
                else
                {
                    return new HttpGenericResponseNoData(
                        SystemCodes.RecordUpdateInternalError,
                        SystemCodes.RecordUpdateInternalError.ToString());
                }
            }
            else
            {
                return new HttpGenericResponseNoData(result.Code, result.Exception.Message);
            }


        }

        /// <summary>
        /// Eliminar un nuevo log.
        /// </summary>   
        /// <param name="_id">id del log.</param>
        public async Task<HttpGenericResponseNoData> Delete(string _id)
        {


            System.Linq.Expressions.Expression<Func<Log, bool>> _filter = a => true;

            if (_id.Length == 24)
            {
                _filter = _filter = a => a._id == _id;
            }

            var usuario = await new DapperMongoManager<Log>(collectionName).ExecObject(_filter);

            var result = await new DapperMongoManager<Log>(collectionName).DeleteOne(usuario.Data, _filter);

            if (result.Code == SystemCodes.Ok)
            {
                if (result.Data != null)
                {
                    return new HttpGenericResponseNoData(result.Code, result.Code.ToString());
                }
                else
                {
                    return new HttpGenericResponseNoData(
                        SystemCodes.RecordDeleteInternalError,
                        SystemCodes.RecordDeleteInternalError.ToString());
                }
            }
            else
            {
                return new HttpGenericResponseNoData(result.Code, result.Exception.Message);
            }

        }

        /// <summary>
        /// Crear un nuevo registro de log.
        /// </summary>   
        /// <param name="log">Objeto con datos del log a crear.</param>
        public async Task<HttpGenericResponseNoData> InsertLog(Log obj)
        {

            var result = await new DapperMongoManager<Log>(collectionName).InsertOne(obj);

            if (result.Code == SystemCodes.Ok)
            {
                if (result.Data != null)
                {
                    return new HttpGenericResponseNoData(result.Code, result.Code.ToString());
                }
                else
                {
                    return new HttpGenericResponseNoData(
                        SystemCodes.RecordCreateInternalError,
                        SystemCodes.RecordCreateInternalError.ToString());
                }
            }
            else
            {
                return new HttpGenericResponseNoData(result.Code, result.Exception.Message);
            }

        }

        /// <summary>
        /// Crear un nuevo registro de log.
        /// </summary>   
        /// <param name="fileName">Nombre del archivo.</param>
        /// <param name="error">Descripción del error.</param>
        /// <param name="errorNumber">Numero del error.</param>
        /// <param name="idUser">Id del usuario que realiza la solicitud.</param>
        /// <param name="lineNumber">Numero de la linea del error.</param>
        public async Task<HttpGenericResponseNoData> InsertLog(string fileName, string error, SystemCodes errorNumber, string idUser = null, int lineNumber = 0)
        {
            try
            {
                var log = new Log { FileName = fileName, Error = error, ErrorNumber = Convert.ToInt32(errorNumber), IdUser = idUser, LineNumber = lineNumber };
                var result = await new DapperMongoManager<Log>(collectionName).InsertOne(log);
                return new HttpGenericResponseNoData(SystemCodes.Ok, SystemCodes.Ok.ToString());
            }
            catch (Exception ex)
            {
                return new HttpGenericResponseNoData(SystemCodes.InternalError, ex.Message);
            }
        }


    }
}
