namespace WebSiteStartNet2023.Models.ModelView
{
    public class PostulanteCreateVM 
    {
        public Postulante Postulante { get; set; }

        public int TecnologiaId { get; set; }
        public List<Tecnologia> Tecnologia { get; set; } 

        public int NivelConocimientoId { get; set; }
        public List<NivelConocimiento> NivelConocimiento { get; set; }

        public int IdiomaId { get; set; }
        public List<Idioma> Idioma { get; set; }

        public int NivelOralId { get; set; }    
        public List<NivelOral> NivelOral { get; set; }

        public int NivelEscrituraId { get; set; }
        public List<NivelEscrito> NivelEscritura { get; set; }

        public int NivelLecturaId { get; set; }
        public List<NivelLectura> NivelLectura { get; set; }

        public  int PuestoTrabajoId  { get; set; }
        public List<PuestoTrabajo> PuestoTrabajos { get; set; }

        public int ExperienciaTrabajoId { get; set; }
        public List<ExperienciaTrabajo> ExperienciaTrabajos { get; set; }
    }
}
