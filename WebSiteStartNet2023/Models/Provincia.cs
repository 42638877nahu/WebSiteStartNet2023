using System.ComponentModel.DataAnnotations;

namespace WebSiteStartNet2023.Models
{
    public class Provincia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public ICollection<Localidad> Localidad { get; set; }
    }
}
