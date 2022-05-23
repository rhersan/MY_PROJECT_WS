using System.Collections.Generic;

namespace MyProject.HttpResponses
{
    /// <summary>
    /// Contenedor de Datos Paginados
    /// </summary>
    public class DataNotPagedResponse<T>
    {


        public DataNotPagedResponse()
        {
            Content = new List<T>();
        }

        public DataNotPagedResponse(List<T> content)
        {
            Content = content;
        }

        /// <summary>
        /// Contenedor de Datos
        /// </summary>
        public List<T> Content { get; set; }

    }
}
