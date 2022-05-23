namespace MyProject.Common.Utilities
{
    /// <summary>
    /// Tipos de Logeo
    /// </summary>
    public enum LogType
    {
        IN,
        OUT
    }
    /// <summary>
    /// Códigos de respuesta
    /// </summary>
    public enum ResponseCodes
    {
        GenericError = 0,
        Success = 1,
        DataInsertError = 2,
        DataReadError = 3,
        DataUpdateError = 4,
        DataInsertWarning = 5,
        DataReadWarning = 6,
        DataUpdateWarning = 7,
        DatabaseConnectionError = 10,
        DataParsingError = 20,
        InvalidDataFormat = 30,
        DataNotFound = 40,
        FileNotFound = 41,
        LocationNotFound = 42,
        ServiceError = 50,
        UIError = 60,
        DuplicatedData = 70,
        DeniedAccess = 80,

    }

    /// <summary>
    /// Tipos de operación en base de datos
    /// </summary>
    public enum TransactionTypes
    {
        Insert = 1,
        Read = 2,
        Update = 3,
        Delete = 4
    }

    /// <summary>
    /// Status de registros en base de datos
    /// </summary>
    public enum ItemStatus
    {
        Enabled = 1,
        Disabled = 0,
        Deleted = 5
    }

    /// <summary>
    /// Enumeracion de tipos de alerta
    /// </summary>
    public enum EAlertTypes
    {
        FulFillmentSchedule = 1,
        FulFillmentVisit = 2,
        FulFillmentSurveyPromoPoint = 3,
        FulFillmentSurvey = 4,
        ScoreSurvey = 5,
        KeyQuestionsSurvey = 6
    }

    public enum ETypeFulfilment
    {
        FulfilmentSchedule = 1,
        FulfilmentVisit = 2
    }

    /// <summary>
    /// Enumeracion para establecer el status de un checkin/out
    /// </summary>
    public enum CheckInStatus
    {
        NotSet = 0,
        CheckInDone = 1,
        CheckOutDone = 2,
        AutoCheckOut = 3
    }

    /// <summary>
    /// Enumeracion para determinar el estatus de una actividad
    /// </summary>
    public enum ActivityCompletionStatus
    {
        NotDone = 1,
        Done = 2
    }

    /// <summary>
    /// Ids tipos de notificaciones push
    /// </summary>
    public enum NotificationPushTypes
    {
        NewClick = 1,
        ReClick = 2,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum SearchByDateType
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3
    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    public enum PermissionsTypes
    {
        Create = 1,
        Search = 2,
        Update = 3,
        Delete = 4,
        Export = 5,
        ChangeStatus = 6,
        SendMessages = 7,
        ChangePassword = 8,
        Enable = 9
    }

    public enum FilterDays
    {
        Today = 1,
        Yesterday = 2,
        Last7Days = 3,
        Last30Days = 4,
        ThisMonth = 5,
        LastMonth = 6
    }

    public enum ReportingPeriod
    {
        daysAgo = 1,
        weeksAgo = 2,
        monthsAgo = 3
    }

    public enum PeriodLimit
    {
        periodLimitDays = 15,
        periodLimitWeeks = 12,
        periodLimitMonths = 6
    }

    public enum IncidenceList
    {
        incidentsNotAssigned = 1,
        incidentsNotAssignedPlusOne = 2
    }

    public enum StatusRecord
    {
        active = 1,
        disactive = 0,
        delete = 5
    }

}
