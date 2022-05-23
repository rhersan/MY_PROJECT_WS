using MyProject.Constraints;

namespace MyProject.Models.Common
{
    public class HttpGenericResponseMS<T>
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
        /// Any exception from the database, if this do not ocurr then it will return null
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


        /// <summary>
        /// Inicializa una nueva instancia
        /// </summary>
        /// <param name="systemCode">Código del sistema</param>
        /// <param name="data">Contenedor de datos</param>
        //public HttpGenericResponse(SystemCodes systemCode, T data, string message)
        //{
        //    SystemCode = systemCode;
        //    Data = data;
        //    Message = message;
        //}
    }
}
