namespace MyProject.Common.Utilities
{
    public struct  ConstantMessages
    {
        /// <summary>
        /// Successful Get information
        /// </summary>
        public const string SuccessfulGetInfoMessage = "Información obtenida correctamente.";
        /// <summary>
        /// Successful Update Message
        /// </summary>
        public const string SuccessfulUpdateMessage = "El registro fue actualizado correctamente.";
        /// <summary>
        /// No Content List
        /// </summary>
        public const string NoContentList = "No se encontraron registros.";
        /// <summary>
        /// No Content Object
        /// </summary>
        public const string NoContentObject = "No se encontró el registro en el sistema.";

        /// <summary>
        /// Error Update Message
        /// </summary>
        public const string ErrorUpdateMessage = "Ha ocurrido un error al actualizar el registro. Intente nuevamente más tarde.";

        /// <summary>
        /// Successful Insert Message
        /// </summary>
        public const string SuccessfulInsertMessage = "Se ha creado el registro correctamente.";

        /// <summary>
        /// Error Insert Message
        /// </summary>
        public const string ErrorInsertMessage = "Ha ocurrido un error al crear el registro. Intente nuevamente más tarde.";

        /// <summary>
        /// Successful Status Message
        /// </summary>
        public const string SuccessfulStatusMessage = "Se ha actualizado el estatus del registro correctamente.";

        /// <summary>
        /// Error Status Message
        /// </summary>
        public const string ErrorStatusMessage = "Ha ocurrido un error al actualizar el estatus del registro. Intente nuevamente más tarde.";

        /// <summary>
        /// Error Status Message In Use
        /// </summary>
        public const string ErrorStatusMessageInUse = "No se puede desactivar el registro ya que se encuentra en uso.";

        /// <summary>
        /// Error Delete Message In Use
        /// </summary>
        public const string ErrorDeleteMessageInUse = "No se puede eliminar el registro ya que se encuentra en uso.";

        /// <summary>
        /// Successful Delete Message
        /// </summary>
        public const string SuccessfulDeleteMessage = "El registro fue eliminado correctamente.";

        /// <summary>
        /// Erro rDelete Message
        /// </summary>
        public const string ErrorDeleteMessage = "Ha ocurrido un error al borrar el registro. Intente nuevamente más tarde.";
        /// <summary>
        /// Error al no obtener elementos de consulta mongo.
        /// </summary>
        public const string SequenceNoElements = "Sequence contains no elements";
        /// <summary>
        /// Error al no obtener elementos de consulta mongo.
        /// </summary>
        public const string GeneralError = "Ha ocurrido un error inesperado. Intente nuevamente más tarde.";

        public const string DuplicityRecordName = "Ya existe un registro con el mismo nombre";

    }
}
