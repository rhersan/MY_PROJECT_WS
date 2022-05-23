using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Common.Utilities
{
    public class GeneralFunctions
    {
        public static string FormatTime (string time)
        {
           
            var Day = time.Split(":")[0];
            var Hour = time.Split(":")[1];
            var Minute = time.Split(":")[2];

            return Day + "d" + Hour + "hr" + Minute + "min" ;
        }
    }
}
