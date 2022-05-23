using MyProject.Constraints;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;
using System.Linq;

namespace MyProject.API.ActionFilters
{


    public class ErrorHandler : ExceptionFilterAttribute
    {
        /// <summary>
        /// Registra en la colección de Logs los errores presentados en el ws.
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            var log = new Business.Implementations.Common.LogService();
            var ex = context.Exception;
            var st = new StackTrace(ex, true);
            var idUser = (context.HttpContext.Request.Headers["idUser"].ToString() == "") ? null : context.HttpContext.Request.Headers["idUser"].ToString();
            var error = st.GetFrames()
              .Select(frame => new
              {
                  FileName = frame.GetFileName(),
                  LineNumber = frame.GetFileLineNumber(),
                  ColumnNumber = frame.GetFileColumnNumber(),
                  Method = frame.GetMethod(),
                  Class = frame.GetMethod().DeclaringType,
              }).FirstOrDefault();
            /*
            try
            {
                LogsWindows.LogsWindows.ErrorLOG(0, ex.ToString(), Convert.ToString(st), idUser);
                _ = log.InsertLog(error.FileName, ex.ToString(), SystemCodes.InternalError, idUser, error.LineNumber);
            }
            catch (Exception)
            {
                LogsWindows.LogsWindows.ErrorLOG(0, ex.ToString(), Convert.ToString(st), idUser);
                _ = log.InsertLog(error.FileName, ex.ToString(), SystemCodes.InternalError, idUser, error.LineNumber);
            }*/
        }
    }
}
