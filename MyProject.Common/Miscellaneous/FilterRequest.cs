using System.Collections.Generic;

namespace MyProject.Miscellaneous
{
    /// <summary>
    /// Filtro de Búsqueda
    /// </summary>
    public class FilterRequest
    {
        /// <summary>
        /// Diccionario los campos y valores para filtrar
        /// </summary>
        public Dictionary<string, object> Filter { get; set; }

        /// <summary>
        /// Objeto filtro
        /// </summary>
        public List<Ordering> Order { get; set; }
    }
}
