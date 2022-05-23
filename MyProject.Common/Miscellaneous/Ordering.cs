namespace MyProject.Miscellaneous
{
    /// <summary>
    /// Ordenamiento de Consultas
    /// </summary>
    public class Ordering
    {
        /// <summary>
        /// Campo
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Tipo de ordenamiento
        /// </summary>
        public TypesOfOrdering Order { get; set; }
    }

    /// <summary>
    /// Tipos de Ordenamiento
    /// </summary>
    public enum TypesOfOrdering
    {
        /// <summary>
        /// Orden Ascendente
        /// </summary>
        Asc,

        /// <summary>
        /// Orden Descendente
        /// </summary>
        Desc
    }
}
