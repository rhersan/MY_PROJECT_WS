using MyProject.Common;
using MyProject.Constraints;
using System.Threading.Tasks;

namespace MyProject.Business.Interfaces.Common
{
    public interface ILogService
    {
        Task<HttpGenericResponseNoData> InsertLog(MyProject.Models.Logs.Log obj);
        Task<HttpGenericResponseNoData> InsertLog(string fileName, string error, SystemCodes errorNumber, string idUser = null, int lineNumber = 0);
    }
}
