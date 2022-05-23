namespace MyProject.Common.Utilities
{
    public struct Constants
    {
        /// <summary>
        /// Dummy Password 
        /// </summary>
        public const string DummyPassword = "AaBbCcXxYyZz0123";
        /// <summary>
        /// Cuando no hay búsqueda predictiva, devuelve el listado.
        /// </summary>
        public const string NoSearch = "NoSearch";
        /// <summary>
        /// Cadena JSON que representa una lista vacía
        /// </summary>
        public const string emptyJSONObject = "[]";
        /// <summary>
        /// ID de la ubicación FTP por defecto, en el servidor local
        /// </summary>
        public const string localFTPHostId = "0";
        /// <summary>
        /// Expresión regular para descomponer el nombre de un archivo obtenido vía FTP
        /// </summary>
        public const string FTPFileNameRegex = "^([d-])([r-][w-][x-])([r-][w-][x-])([r-][w-][x-])\\s+(\\d+)\\s+(\\w+)\\s+(\\w+)\\s+(\\d+)\\s+(\\w{3}\\s+\\d{1,2}\\s{1,2}[0-9:]{4,})\\s+(.+)$";
        /// <summary>
        /// Mostrar titulo cuando el click este por ser escalado.
        /// </summary>
        public const string Test = "Test.";
    }


    public struct HierarchiesNames
    {
        public const string National = "Nacional";

        public const string All = "Todas las ubicaciones";

        public const string Zone = "Zona";

        public const string Plaza = "Plaza";

        public const string OperatingCity = "Ciudad Operativa";

        public const string Pharmacy = "Farmacia";
    }

    public struct Orders
    {
        public const string Desc = "desc";

        public const string Asc = "asc";
    }

    public struct Confirmed
    {
        public const string ConfirmedProcess = "Confirmado";
        public const string ConfirmedRF = "Confirmado RF";

    }
}
