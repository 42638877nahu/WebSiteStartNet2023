using System.ComponentModel.DataAnnotations;

namespace WebSiteStartNet2023.Models
{
    public class Postulante
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string DNI { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }
        
        [Required]
        public string CodigoArea { get; set; }

        [Required]
        public string TelefonoCelular { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string ArchivoCV { get; set; }
        public DateTime FechaAlta { get; set; }

        //Foreign Keys + relaciones

        [Required]
        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; }

        //[Required]
        //public int IdiomaPostulanteId { get; set; }
        //public IdiomaPostulante IdiomaPostulante { get; set; }

        //[Required]
        //public int TecnologiaPostulanteId { get; set; }
        //public ICollection<TecnologiaPostulante> Tecnologias { get; set; }

        //[Required]
        //public int PuestoTrabajoPostulanteId { get; set; }
        //public ICollection<PuestoTrabajoPostulante> PuestosTrabajoPostulante { get; set; }

    }
}
