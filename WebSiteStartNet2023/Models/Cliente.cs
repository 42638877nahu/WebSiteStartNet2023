using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebSiteStartNet2023.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required,DisplayName("Nombre Fantasia")]
        public string? NombreFantasia { get; set; }

        public string? NombreLogo { get; set; }

        [NotMapped]
        public IFormFile? FotoLogo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        public int Orden { get; set; }

        [Required, DisplayName("Visible en Home")]
        public bool VisibleEnHome { get; set; }

        [ForeignKey("RubroCliente")]
        public int IdRubroCliente { get; set; }

        public RubroCliente? RubroCliente { get; set; }
    }
}
