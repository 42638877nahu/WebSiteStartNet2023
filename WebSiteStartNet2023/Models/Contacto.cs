using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace WebSiteStartNet2023.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Apellido { get; set; }

        [Required]
        public string? AreaCelular { get; set;}

        [Required]
        public string? TeléfonoCelular { get;set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        public string? Mensaje { get; set;}

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public string? Area { get; set;}

        public string? SubArea { get; set; }
    }
}
