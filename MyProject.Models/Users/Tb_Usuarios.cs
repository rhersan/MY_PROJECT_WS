using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Users
{
    public class Tb_Usuarios
    {
        /// <summary>
        /// Identificador del registro
        /// </summary>
        [Key]
        public int Id { set; get; }

        public string Nombre { set; get; }

        public string ApellidoPaterno { set; get; }

        public string ApellidoMaterno { set; get; }

        public string Usuario { set; get; }

        public string Password { set; get; }

        public int Status { set; get; }

        public string Token { get; set; }

    }
}
