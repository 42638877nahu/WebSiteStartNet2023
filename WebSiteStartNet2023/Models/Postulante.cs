using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string? ArchivoCV { get; set; }

        [NotMapped]
        public IFormFile? ArchivoCVFile { get; set; }
        public DateTime FechaAlta { get; set; }

        //Foreign Keys + relaciones

        [Required]
        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; } //quitar


        public ICollection<IdiomaPostulante> IdiomasPostulantes { get; set; }
        public ICollection<TecnologiaPostulante> TecnologiasPostulantes { get; set; }
        public ICollection<PuestoTrabajoPostulante> PuestosTrabajoPostulantes { get; set; }

    }
}
