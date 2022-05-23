using System;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class OpeFile : BaseModel
    {

        /// <summary>
        /// Nombre con que se retornara el archivo al ser consultado
        /// </summary>
        /// <returns></returns>
        [Required]
        [MaxLength(255)]
        public string name { get; set; }


        /// <summary>
        /// Tipo de archivo registrado
        /// </summary>
        /// <returns></returns>
        [Required]
        [MaxLength(100)]
        public string contentType { get; set; }

        /// <summary>
        /// Tamaño en bites del archivo
        /// </summary>
        /// <returns></returns>
        [Required]
        public long size { get; set; }

        /// <summary>
        /// Una descripcion alternativa para el archivo
        /// </summary>
        /// <returns></returns>
        [MaxLength(400)]
        public string description { get; set; }

        /// <summary>
        /// La ruta de almacenamiento del archivo, puede ser absoluta o relativa
        /// </summary>
        /// <returns></returns>
        [Required]
        [MaxLength(255)]
        public string url { get; set; }

        /// <summary>
        /// Identificador unico que permite evitar la insercion duplicada cuando se recibe desde moviles
        /// </summary>
        /// <returns></returns>
        [Required]
        public Guid offlineId { get; set; } = new Guid();


        /// <summary>
        /// Indica si el registro es temporal y se debe eliminar una vez descargado o leido
        /// </summary>
        /// <returns></returns>
        public Boolean isTemp { get; set; } = false;

    }
}