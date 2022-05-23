namespace MyProject.Common.HttpResponses
{
    public class MaintenanceResponse
    {
        /// <summary>
        /// Código del sistema
        /// </summary>
        public int ResponseCode { get; set; }

        /// <summary>
        /// Cadena de conexión de mongodb.
        /// </summary>
        public string MongoConnection { get; set; }

        /// <summary>
        /// URL del servicio de notificaciones.
        /// </summary>
        public string NotificationsURL { get; set; }

        /// <summary>
        /// Mensaje del consumo del servicio de notificación.
        /// </summary>
        public string NotificationMessage { get; set; }

        /// <summary>
        /// Versionamiento de la API.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Minutos en el que se ejecutara el servicio de windows service programado. (60000ms = 1m)
        /// </summary>
        public int WindowsServiceTimer { get; set; }


    }
}
