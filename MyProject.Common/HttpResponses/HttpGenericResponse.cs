using MyProject.Common.Utilities;
using MyProject.Constraints;

namespace MyProject.Common
{
    /// <summary>
    /// Respuesta HTTP
    /// </summary>
    public class HttpGenericResponse<T>
    {
        /// <summary>
        /// Contenedor de Datos
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Código del sistema
        /// </summary>
        public SystemCodes SystemCode { get; set; }

        /// <summary>
        /// Código del sistema
        /// </summary>
        public int TotalRows { get; set; }

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

        public ShowFields  Fields { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia
        /// </summary>
        /// <param name="systemCode">Código del sistema</param>
        /// <param name="data">Contenedor de datos</param>
        public HttpGenericResponse(SystemCodes systemCode, T data, string message, int totalRows)
        {
            SystemCode = systemCode;
            Data = data;
            Message = message;
            TotalRows = totalRows;
        }

        public HttpGenericResponse(SystemCodes systemCode, T data, string message, int totalRows, ShowFields fields)
        {
            SystemCode = systemCode;
            Data = data;
            Message = message;
            TotalRows = totalRows;
            Fields = fields;
        }
    }
}
