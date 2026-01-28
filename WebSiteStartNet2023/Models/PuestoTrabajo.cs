using System.ComponentModel.DataAnnotations;

namespace WebSiteStartNet2023.Models
{
    public class PuestoTrabajo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
