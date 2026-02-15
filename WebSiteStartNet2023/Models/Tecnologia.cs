using System.ComponentModel.DataAnnotations;

namespace WebSiteStartNet2023.Models
{
    public class Tecnologia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        //Relaciones
        //public List<TecnologiaPostulante>? TecnologiaPostulantes { get; set; }
    }
}
