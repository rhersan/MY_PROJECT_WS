using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Common
{
    public class ResultStoredProcedure
    {
        public int errorCode { get; set; }
        public string errorCode_s { get; set; }
        public string message { get; set; }
        public string retur_value_s { get; set; }
        public int retur_value { get; set; }

    }
}
