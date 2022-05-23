using System.ComponentModel.DataAnnotations;


namespace MyProject.Miscellaneous
{
    public class PageRequest : FilterRequest
    {
        /// <summary>
        /// Pagina a consultar
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int SelectedPage { get; set; }

        /// <summary>
        /// Numero de registros por pagina
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

    }

}