using MyProject.Constraints;

namespace MyProject.Common
{
    /// <summary>
    /// Respuesta HTTP
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        /// Código del sistema
        /// </summary>
        public SystemCodes SystemCode { get; }

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
        /// Inicializa una nueva instancia
        /// </summary>
        /// <param name="systemCode">Código del sistema</param>
        public HttpResponse(SystemCodes systemCode)
        {
            SystemCode = systemCode;
        }
    }
}
