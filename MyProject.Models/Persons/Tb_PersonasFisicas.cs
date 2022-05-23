using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Persons
{
    public class Tb_PersonasFisicas
    {
        /// <summary>
        /// Identificador del registro
        /// </summary>
        [Key]
        public int IdPersonaFisica { set; get; }

        public DateTime FechaRegistro { set; get; }

        public DateTime FechaActualizacion { set; get; }
        
        public string Nombre { set; get; }

        public string ApellidoPaterno { set; get; }

        public string ApellidoMaterno { set; get; }

        public string RFC { set; get; }

        public DateTime FechaNacimiento { set; get; }

        public int UsuarioAgrega { set; get; }

        public int Activo { set; get; }
    }
}
