﻿using MyProject.Constraints;

namespace MyProject.Common
{
    /// <summary>
    /// Respuesta HTTP
    /// </summary>
    public class HttpGenericResponseNoData
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


        /// <summary>
        /// Inicializa una nueva instancia
        /// </summary>
        /// <param name="systemCode">Código del sistema</param>
        /// <param name="data">Contenedor de datos</param>
        public HttpGenericResponseNoData(SystemCodes systemCode, string message)
        {
            SystemCode = systemCode;
            Message = message;
        }
    }
}
