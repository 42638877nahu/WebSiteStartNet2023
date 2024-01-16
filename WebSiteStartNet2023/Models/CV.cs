using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteStartNet2023.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Apellido { get; set; }

        [Required]
        public string? Localidad { get; set; }

        [Required]
        public string? Provincia { get; set; }

        [Required]
        public string? CodigoArea { get; set; }

        [Required]
        public string? TeléfonoCelular { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        public string? NombreArchivo { get; set; }

        [NotMapped]
        public IFormFile? Archivo { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }
    }
}
