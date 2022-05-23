using System;

namespace MyProject.Miscellaneous
{
    /**
     * Define la estructura del Payload en los Tokens manejados en el sistema
     */
    public class JwtBasePayload
    {
        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Identificador de la empresa
        /// </summary>
        public Guid CompanyId { get; set; }

        /// <summary>
        /// Identificador del perfil de usuario
        /// </summary>
        public Guid ProfileId { get; set; }

        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// Lenguaje preferido por el usuario
        /// </summary>
        public string Language { get; set; }
    }
}