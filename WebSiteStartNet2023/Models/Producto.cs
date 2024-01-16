using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSiteStartNet2023.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public string? NombreSlider { get; set; }

        [NotMapped]
        public IFormFile? FotoSlider { get; set; }

        [Required]
        public string? Detalle { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        public string? NombreHome { get; set; }

        [NotMapped]
        public IFormFile? FotoHome { get; set; }
    }
}
