namespace WebSiteStartNet2023.Models
{
    public class Localidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoPostal { get; set; }

        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
    }
}
