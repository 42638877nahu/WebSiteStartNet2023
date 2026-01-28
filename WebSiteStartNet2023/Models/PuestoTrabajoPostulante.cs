namespace WebSiteStartNet2023.Models
{
    public class PuestoTrabajoPostulante
    {
        public int Id { get; set; }

        public int PostulanteId { get; set; }
        public Postulante Postulante { get; set; }

        public int PuestoTrabajoId { get; set; }
        public PuestoTrabajo PuestoTrabajo { get; set; }

        public int ExperienciaTrabajoId { get; set; }
        public ExperienciaTrabajo ExperienciaTrabajo { get; set; }
    }
}
