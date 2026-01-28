namespace WebSiteStartNet2023.Models
{
    public class TecnologiaPostulante
    {
        public int Id { get; set; }

        public int PostulanteId { get; set; }
        public Postulante Postulante { get; set; }

        public int TecnologiaId { get; set; }
        public Tecnologia Tecnologia { get; set; }

        public int NivelConocimientoId { get; set; }
        public NivelConocimiento NivelConocimiento { get; set; }
    }
}
