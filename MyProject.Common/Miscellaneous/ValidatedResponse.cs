using MyProject.Common;

namespace MyProject.Miscellaneous
{
    public class ValidatedResponse
    {
        public HttpGenericResponse<JwtBasePayload> ServerMessage { get; set; }

        public int StatusCode { get; set; }

        public ValidatedResponse(HttpGenericResponse<JwtBasePayload> serverMessage, int statusCode)
        {
            ServerMessage = serverMessage;
            StatusCode = statusCode;
        }
    }
}