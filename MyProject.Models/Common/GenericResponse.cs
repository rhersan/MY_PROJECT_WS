using MyProject.Common.Utilities;
using MyProject.Constraints;
using System;

namespace MyProject.Models.Common
{
    /// <summary>
    /// Class parameter to map the result set from the database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericResponse<T>
    {
        /// <summary>
        /// HttpCode of reponse
        /// </summary>        
        public SystemCodes Code { get; set; }
        /// <summary>
        /// Any exception from the database, if this do not ocurr then it will return null
        /// </summary>
        public Exception Exception { get; set; }
        /// <summary>
        /// Message from the insert operation in db
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Mapped data from the database
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Total Rows affected
        /// </summary>
        public int TotalRows { get; set; }

        public ShowFields Fields { get; set; }
    }
}
