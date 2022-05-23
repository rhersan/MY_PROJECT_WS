using System;

namespace MyProject.HttpResponses
{
    /// <summary>
    /// Brinda soporte para las respuestas HTTP de Google ReCaptcha
    /// </summary>
    public class ReCaptchaResponse
    {
        /// <summary>
        /// Determina si la verificación del token es satisfactoria
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Momento en el cual fue generado el token reCAPTCHA
        /// </summary>
        public DateTime ChallengeTs { get; set; }

        /// <summary>
        /// Host desde el cual se generó el token reCAPTCHA
        /// </summary>
        public string Hostname { get; set; }
    }
}
