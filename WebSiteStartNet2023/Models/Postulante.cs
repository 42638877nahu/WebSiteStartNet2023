using System;
using System.Collections.Generic;
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

        public string DNI { get; set; }

        public DateTime FechaNacimiento { get; set; }
        public int ProvinciaId { get; set; }
        //public Provincia Provincia { get; set; }

        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; }

        public string CodigoArea { get; set; }
        public string TelefonoCelular { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public int NivelConocimientoId { get; set; }

        public int PuestoTrabajoId { get; set; }

        public string ArchivoCV { get; set; }
        public DateTime FechaAlta { get; set; }

        // RELACIONES
        public ICollection<NivelConocimiento> NivelConocimientos { get; set; }
        public ICollection<TecnologiaPostulante> Tecnologias { get; set; }
        public ICollection<IdiomaPostulante> Idiomas { get; set; }
        public ICollection<PuestoTrabajoPostulante> PuestosTrabajo { get; set; }
    }
}
