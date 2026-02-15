using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteStartNet2023.Models
{
    public class NivelLectura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        //[ForeignKey("NivelLecturaId")]
        //public List<IdiomaPostulante>? IdiomaPostulante { get; set; }
    }
}
