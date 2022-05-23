using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models.Products
{
    [Table("ADM_PRODUCTS")]
    public class ADM_PRODUCTS
    {
        /// <summary>
        /// Identificador del registro
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Ingredientes del producto
        /// </summary>
        public string Ingredients { get; set; }

        /// <summary>
        /// Peso
        /// </summary>

        public decimal Weight { get; set; }

        /// <summary>
        /// Calorias
        /// </summary>
        public decimal Calories { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Imagen del producto
        /// </summary>
        public string ImgSrc { get; set; }

        /// <summary>
        /// Perfil
        /// </summary>
        [Required]
        public int IdCategory { get; set; }

        public int Status { get; set; }
    }
}
