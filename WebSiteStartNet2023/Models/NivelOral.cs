using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteStartNet2023.Models
{
    public class NivelOral
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        //Relaciones
        //[ForeignKey("NivelOralId")]
        //public List<IdiomaPostulante>? IdiomaPostulante { get; set; }
    }
}
