namespace WebSiteStartNet2023.Models
{
    public class IdiomaPostulante
    {
        public int Id { get; set; }
        public int PostulanteId { get; set; }
        public Postulante Postulante { get; set; }

        public int IdiomaId { get; set; }
        public Idioma Idioma { get; set; }

        public int NivelOralId { get; set; }
        public NivelOral NivelOral { get; set; }

        public int NivelEscrituraId { get; set; }
        public NivelEscrito NivelEscritura { get; set; }
        
        public int NivelLecturaId { get; set; }
        public NivelLectura NivelLectura { get; set; }
    }
}
