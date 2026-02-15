using System.ComponentModel.DataAnnotations;

namespace WebSiteStartNet2023.Models
{
    public class ExperienciaTrabajo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        //Relaciones
        //public List<PuestoTrabajoPostulante>? PuestoTrabajoPostulantes { get; set; }
    }
}
