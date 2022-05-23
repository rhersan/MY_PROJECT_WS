using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Common.Utilities
{
    public class ShowFields
    {
        /// <summary>
        /// Propiedades para Mostrar ciertas columnas en la consulta de clicks
        /// </summary>
        public bool ShowTimeStatusCurrent { get; set; }
        public bool ShowGestionZoneName { get; set; }
        public bool ShowIdPharmacyName { get; set; }
        public bool ShowAreaName { get; set; }
        public bool ShowTimeExpired { get; set; }
        public bool ShowTimeNoAttended { get; set; }
        public bool ShowTimeInProccess { get; set; }
        public bool ShowTimeResolved { get; set; }
        public bool ShowTimeTotalActive { get; set; }
    }
}
