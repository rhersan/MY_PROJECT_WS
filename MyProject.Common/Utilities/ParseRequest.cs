using MyProject.Constraints;
using System.Net;

namespace MyProject.Common.Utilities
{
    public struct ParseRequest
    {
        public static SystemCodes ConvertHttpStatusToSystemsCode(HttpStatusCode status)
        {
            SystemCodes resp;
            switch (status)
            {
                case HttpStatusCode.NotFound:
                    resp = SystemCodes.NotFound;
                    break;
                case HttpStatusCode.BadRequest:
                    resp = SystemCodes.InternalError;
                    break;
                case HttpStatusCode.Unauthorized:
                    resp = SystemCodes.UnauthorizedCredentials;
                    break;
                case HttpStatusCode.OK:
                    resp = SystemCodes.Ok;
                    break;
                case HttpStatusCode.NoContent:
                    resp = SystemCodes.NoContent;
                    break;
                default:
                    resp = SystemCodes.InternalError;
                    break;
            }
            return resp;
        }

        public static HttpStatusCode ConvertSystemCodesToHttpStatus(SystemCodes status)
        {
            HttpStatusCode resp;
            switch (status)
            {
                case SystemCodes.Ok:
                    resp = HttpStatusCode.OK;
                    break;
                case SystemCodes.NoContent:
                    resp = HttpStatusCode.NoContent;
                    break;
                case SystemCodes.TokenExpiredException:
                    resp = HttpStatusCode.Unauthorized;
                    break;
                case SystemCodes.UnauthorizedCredentials:
                    resp = HttpStatusCode.Unauthorized;
                    break;
                default:
                    resp = HttpStatusCode.InternalServerError;
                    break;
            }
            return resp;
        }
    }
}
