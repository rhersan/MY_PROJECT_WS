using MyProject.Constraints;

namespace MyProject.Models.Common
{
    public class HttpGenericResponseNoDataMS
    {
        /// <summary>
        /// Código del sistema
        /// </summary>
        public SystemCodes SystemCode { get; set; }

        /// <summary>
        /// Nombre del código del sistema
        /// </summary>
        public string SystemCodeName
        {
            get
            {
                return SystemCode.ToString();
            }
        }

        /// <summary>
        /// Mensaje generico de respuesta
        /// </summary>
        public string Message { get; set; }


        public HttpGenericResponseNoDataMS()
        {
            SystemCode = SystemCodes.Ok;
            Message = "";
        }


        /// <summary>
        /// Inicializa una nueva instancia
        /// </summary>
        /// <param name="systemCode">Código del sistema</param>
        /// <param name="data">Contenedor de datos</param>
        public HttpGenericResponseNoDataMS(SystemCodes systemCode, string message)
        {
            SystemCode = systemCode;
            Message = message;
        }
    }
}
