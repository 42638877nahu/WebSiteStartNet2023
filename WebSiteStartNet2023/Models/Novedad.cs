using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteStartNet2023.Models
{
    public class Novedad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Titulo { get; set; }

        [Required]
        public string? NombreFoto { get; set; }

        [NotMapped]
        public IFormFile? Foto { get; set; }

        [Required]
        public string? Detalle { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}
