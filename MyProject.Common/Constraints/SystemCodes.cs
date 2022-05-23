namespace MyProject.Constraints
{
    /// <summary>
    /// Códigos del Sistema
    /// </summary>
    public enum SystemCodes
    {
        #region Genericos

        /// <summary>
        /// El registro especificado no se encuentra registrado
        /// </summary>
        NotFound,

        /// <summary>
        /// La solicitud ha sido procesada correctamente
        /// </summary>
        Ok,

        /// <summary>
        /// Se ha producido un comportamiento inesperado y se debe consultar el LOG del sistema
        /// </summary>
        InternalError,

        /// <summary>
        /// La consulta realizada no ha producido ningún resultado
        /// </summary>
        NoContent,

        /// <summary>
        /// La autorización CRUD correspondiente no está registrada
        /// </summary>
        CrudAuthorizationNotFound,

        /// <summary>
        /// La autorización correspondiente no está registrada
        /// </summary>
        AuthorizationNotFound,

        /// <summary>
        /// El registro especificado no admite edición
        /// </summary>
        NonEditableRecord,

        /// <summary>
        /// El registro especificado no admite eliminación
        /// </summary>
        NonRemovableRecord,

        /// <summary>
        /// Ya existe un registro con el mismo nombre
        /// </summary>
        DuplicityRecord,

        /// <summary>
        /// Se ha producido un error al intentar crear un nuevo registro
        /// </summary>
        RecordCreateInternalError,

        /// <summary>
        /// Se ha producido un error al intentar modificar un registro
        /// </summary>
        RecordUpdateInternalError,

        /// <summary>
        /// Se ha producido un error al intentar eliminar un registro
        /// </summary>
        RecordDeleteInternalError,

        /// <summary>
        /// No existe una o más de las llaves foráneas recibidas
        /// </summary>
        NonExistentForeignKey,

        /// <summary>
        /// El modelo recibido está serializado de forma incorrecta
        /// </summary>
        IncorrectSerialization,

        /// <summary>
        /// El modelo indicado no existe para ser exportado
        /// </summary>
        ModelNotFound,

        /// <summary>
        /// El archivo solicitado no existe
        /// </summary>
        FileNotFound,

        /// <summary>
        /// Rango de fechas invalido
        /// </summary>
        InvalidDateRange,

        /// <summary>
        /// Numero de días de consulta excedidos
        /// </summary>
        ExceedConsultDays,
        #endregion

        #region Auth

        /// <summary>
        /// EL usuario se ha autenticado exitosamente
        /// </summary>
        SuccessfulLogin,

        /// <summary>
        /// EL usuario se ha autenticado exitosamente
        /// </summary>
        SuccessfulPasswordChange,

        /// <summary>
        /// Los datos prorcionados en el Payload no cumplen con las especificaciones del DTO
        /// </summary>
        ModelStateErrors,

        /// <summary>
        /// El token ha sido rechazado por Google
        /// </summary>
        UnauthorizedRecaptchaToken,

        /// <summary>
        /// Las credenciales son incorrectas
        /// </summary>
        UnauthorizedCredentials,

        /// <summary>
        /// El cambio de password no esta permitido ya que el usuario no tiene estatus de primer ingreso
        /// </summary>
        FirstPasswordChangeNotValid,

        /// <summary>
        /// El correo electrónico especificado no se encuentra registrado
        /// </summary>
        NotFoundEmail,

        /// <summary>
        /// Se ha producido un error al enviar el correo electrónico solicitado
        /// </summary>
        EmailSendError,



        #endregion

        #region AdmCompany

        /// <summary>
        /// Empresa no encontrada
        /// </summary>
        NotFoundCompany,

        /// <summary>
        /// El alias de empresa especificado no pertenece a ninguna empresa
        /// </summary>
        NotFoundCompanyAlias,

        /// <summary>
        /// La empresa especificada no se encuentra activa
        /// </summary>
        InactiveCompany,

        #endregion

        #region AdmCompanyParameter

        /// <summary>
        /// Algunos parametros de configuracion no estan definidos para esta empresa
        /// </summary>
        SomeParamsAreNotSetYet,

        #endregion

        #region AdmUser

        /// <summary>
        /// No fue posible ubicar al usuario asociado a la solicitud
        /// </summary>
        UserNotFound,

        /// <summary>
        /// Se ha producido un error al intentar modificar el registro del usuario especificado
        /// </summary>
        UserUpdateInternalError,

        /// <summary>
        /// La cuenta del usuario especificado ha sido bloqueada temporalmente y debe esperar el tiempo configurado o solicitar al administrador el desbloqueo
        /// </summary>
        UserAccountTemporaryBlocked,

        /// <summary>
        /// La cuenta del usuario especificado ha sido bloqueada y el usuario debe comunicarse con el administrador
        /// </summary>
        UserAccountBlocked,


        /// <summary>
        /// El usuario está ingresando por primera vez al sistema o bien, su contrasenia ha sido reestablecida
        /// </summary>
        FirstAccessOrPasswordReset,

        /// <summary>
        /// La contrasenia seleccionada por el usuario ya fue usada recientemente
        /// </summary>
        RecentlyUsedPassword,

        /// <summary>
        /// Se ha producido un error al intentar registrar la contrasenia histórica del usuario
        /// </summary>
        PasswordHistoryInsertInternalError,

        #endregion

        #region GlobalConfigs

        /// <summary>
        /// La peticion no contiene las cabeceras necesarias
        /// </summary>
        InvalidHeaders,

        /// <summary>
        /// Los headers de la peticion no contienen valores validos
        /// </summary>
        InvalidHeaderValue,

        /// <summary>
        /// La version de la aplicacion movil que se conecta no es valida
        /// </summary>
        InvalidAppVersion,

        #endregion

        #region Status

        /// <summary>
        /// Estatus no encontrado
        /// </summary>
        NotFoundStatus,

        #endregion

        #region Token

        /// <summary>
        /// 
        /// </summary>
        TokenExpiredException,

        /// <summary>
        /// 
        /// </summary>
        SignatureVerificationException,

        #endregion

        #region Notification

        /// <summary>
        /// La dirección URL y la ruta de solicitud no coincidían con ningún servicio disponible
        /// </summary>
        NotFoundUrl,

        /// <summary>
        /// No se pudo procesar su solicitud
        /// </summary>
        UnprocessedRequest,

        /// <summary>
        /// Una respuesta predeterminada cuando no se encuentra un recurso
        /// </summary>
        ResourceNotFound,

        /// <summary>
        /// Información requerida
        /// </summary>
        InformationRequired,

        /// <summary>
        /// No proporcionó credenciales válidas
        /// </summary>
        InvalidCredentials,

        /// <summary>
        /// Era imposible conectar con el broker
        /// </summary>
        ConnectionError,

        /// <summary>
        /// No se obtuvo el token de firebase
        /// </summary>
        GetTokenError,
        #endregion

        #region AdmProfile

        /// <summary>
        /// El perfil del usuario ha sido desactivado, se debe cerrar sesion y redirigir a login
        /// </summary>
        InactiveProfile,

        /// <summary>
        /// Se ha producido un error al intentar crear el registro en AdmAuthorization
        /// </summary>
        AuthorizationCreateInternalError,

        /// <summary>
        /// Se ha producido un error al intentar crear el registro en AdmAuthorizationActions
        /// </summary>
        AuthorizationActionsCreateInternalError,

        /// <summary>
        /// No existe la llave foránea recibida de RelCompanyFunctionality
        /// </summary>
        CompanyFunctionalityNonExistentForeignKey,
        #endregion

        #region Actions
        /// <summary>
        /// Operacion no permitida por reglas de negocio establecidas
        /// </summary>
        NotAllowedAction,
        #endregion


    }
}
