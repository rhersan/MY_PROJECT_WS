using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Common.Utilities
{
    public static class StaticConfig
    {
        public static string MongoDBColletionName { get; set; }

        public static string MongoDBConnectionString { get; set; }

        public static string SQLConnectionString { get; set; }

        public static string MongoDBDatabaseName { get; set; }


        /// <summary>
        /// URL base de Microservicios de Aplicaciones Telstock
        /// </summary>
        public static string MicroservicesBaseURL { get; set; }
        /// <summary>
        /// ID de aplicación en Microservicios Telstock
        /// </summary>
        public static string MicroservicesApplicationID { get; set; }
        /// <summary>
        /// Password de aplicación en Microservicios Telstock
        /// </summary>
        public static string MicroservicesApplicationPassword { get; set; }
        /// <summary>
        /// Endpoint al cual pertenece el token
        /// </summary>
        public static string MicroservicesTokenEndPoint { get; set; }
        /// <summary>
        /// Endpoint para validar el token
        /// </summary>
        public static string MicroservicesValidateTokenEndPoint { get; set; }
        /// <summary>
        /// URL para servicios de clickview
        /// </summary>
        public static string MicroservicesClickViewURL { get; set; }
        /// <summary>
        /// Nombres de los métodos (endpoints) que no requieren de un token de autenticación
        /// </summary>
        public static List<string> NoAuthEndpoints { get; set; }
        /// <summary>
        /// Mensaje de error genérico para cualquier método cuando ocurre una excepción
        /// </summary>
        public static string ExceptionMessage { get; set; }
        /// <summary>
        /// Mensaje de advertencia genérico para cualquier método cuando se completa un proceso con errores
        /// </summary>
        public static string WarningMessage { get; set; }
        /// <summary>
        /// Identificador del tipo de ambiente actual (producción = 1, desarrollo = 2, qa)
        /// </summary>
        public static string CurrentEnvironment { get; set; }
        /// <summary>
        /// Identificador de la URL del BackOffice TManager del ambiente actual
        /// </summary>
        public static string BackOfficeURL { get; set; }
        /// <summary>
        /// Ruta en servidor local para almacenar archivos temporales
        /// </summary>
        public static string TempFilesPath { get; set; }
        /// <summary>
        /// Ruta en servidor local para almacenar archivos temporales
        /// </summary>
        public static string AlertNotificationsTopic { get; set; }
        /// <summary>
        /// Usuario de la cuenta de correo para envío de notificaciones
        /// </summary>
        public static string EmailUserName { get; set; }
        /// <summary>
        /// Contraseña de la cuenta de correo para envío de notificaciones
        /// </summary>
        public static string EmailPassword { get; set; }
        /// <summary>
        /// Puerto del servidor de correo para envío de notificaciones
        /// </summary>
        public static int EmailPort { get; set; }
        /// <summary>
        /// Cuenta de correo para envío de notificaciones
        /// </summary>
        public static string EmailSenderAddress { get; set; }
        /// <summary>
        /// Nombre del remitente en el correo para envío de notificaciones
        /// </summary>
        public static string EmailSenderName { get; set; }
        /// <summary>
        /// URL del servidor SMTP para envío de notificaciones
        /// </summary>
        public static string EmailSMTPServer { get; set; }
        /// <summary>
        /// Tiempo en de espera en segundos para la ejecución de comandos SQL
        /// </summary>
        public static int SQLCommandTimeout { get; set; }
        /// <summary>
        /// Mensaje por defecto para el encabezado del correo de notificación de alerta
        /// </summary>
        public static string DefaultMessage { get; set; }
        /// <summary>
        /// Objetivo diario de actividades realizadas por usuario
        /// </summary>
        public static int DailyTargetActivities { get; set; }
        /// <summary>
        /// Objetivo diario de visitas ejecutadas por usuario
        /// </summary>
        public static int DailyTargetVisits { get; set; }
        /// <summary>
        /// Objetivo semanal de actividades realizadas por usuario
        /// </summary>
        public static int WeeklyTargetActivities { get; set; }
        /// <summary>
        /// Objetivo semanal de visitas ejecutadas por usuario
        /// </summary>
        public static int WeeklyTargetVisits { get; set; }
        /// <summary>
        /// Objetivo mensual de actividades realizadas por usuario
        /// </summary>
        public static int MonthlyTargetActivities { get; set; }
        /// <summary>
        /// Objetivo mensual de visitas ejecutadas por usuario
        /// </summary>
        public static int MonthlyTargetVisits { get; set; }
        /// <summary>
        /// Tiempo mínimo de duración de una visita agendada para considerarse como cumplimiento válido
        /// </summary>
        public static int MinimunVisitMinutes { get; set; }
        /// <summary>
        /// Tiempo de expiración del token jwt en horas
        /// </summary>
        public static int JWTExpirationTime { get; set; }
        /// <summary>
        /// Clave secreta para generar el JWT
        /// </summary>
        public static string JWTSecret { get; set; }
        /// <summary>
        /// Clave para encriptar datos
        /// </summary>
        public static string EncryptionKey { get; set; }
        /// <summary>
        /// Ruta absoluta para guardar imagenes
        /// </summary>
        public static string ImagesAbsolutePath { get; set; }
        /// <summary>
        /// Versión de la API.
        /// </summary>
        public static string Version { get; set; }
        /// <summary>
        /// Nombre del log en windows.
        /// </summary>
        public static string Logs { get; set; }
        /// <summary>
        /// URL de la foto de usuario.
        /// </summary>
        public static string UserAvatarURL { get; set; }
        /// <summary>
        /// URL base de Servicio de Ms de notificaciones
        /// </summary>
        public static string UrlMS { get; set; }
        /// <summary>
        /// Nombre de la aplicación del MS
        /// </summary>
        public static string MsAppName { get; set; }
        /// <summary>
        /// Password para accesar al MS
        /// </summary>
        public static string MsPassword { get; set; }
        /// <summary>
        /// ID de la aplicación del MS
        /// </summary>
        public static string MsAppId { get; set; }
        /// <summary>
        /// Porcentaje para envío de notificación en proceso de Clicks.
        /// </summary>
        public static string NotificationPercentage { get; set; }

        /// <summary>
        /// Habilitar envio de notificaciones
        /// </summary>
        public static bool EnabledNotifications { get; set; }


        /// <summary>
        /// Hora en formato 24 en el que se ejecutara el envio de notificaciones cuando el tiempo de confirmación este inactivo
        /// </summary>
        public static int TimeHoursExecuteConfirmation { get; set; }

        /// <summary>
        /// Minutos en el que se ejecutara el envio de notificaciones cuando el tiempo de confirmación este inactivo
        /// </summary>
        public static int TimeMinutesExecuteConfirmation { get; set; }

        /// <summary>
        /// Minutos en el que se ejecutara el servicio de windows service programado. (60000ms = 1m)
        /// </summary>
        public static int ConfiguredRuntime { get; set; }
    }
}
