namespace MyProject.HttpResponses
{
    /// <summary>
    /// Contenedor de datos
    /// </summary>
    public class DataResponse<T>
    {
        /// <summary>
        /// Contenedor de Datos
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia
        /// </summary>
        /// <param name="data">Datos</param>
        public DataResponse(T data)
        {
            Data = data;
        }
    }
}
