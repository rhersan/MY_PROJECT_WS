using Dapper;
using MyProject.Models.Common;
using System.Threading.Tasks;

namespace MyProject.Data.Dapper.Interfaces
{
    public interface IDapperMongoManager<T>
    {
        /// <summary>
        /// Gets a single pre-defined object from database
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GenericResponse<T>> ExecObject(string query);
        /// <summary>
        /// Gets a single pre-defined object from database with paramerets
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<GenericResponse<T>> ExecObject(string query, DynamicParameters parameters);
        /// <summary>
        /// Gets a list of a pre-defined object from database
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<GenericResponse<T>> ExecList(string query);
        /// <summary>
        /// Gets a list of a pre-defined object from database with paramerets
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<GenericResponse<T>> ExecList(string query, DynamicParameters parameters);
    }
}
