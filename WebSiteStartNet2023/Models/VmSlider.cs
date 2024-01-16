using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebSiteStartNet2023.Models
{
    public class VmSlider
    {
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? Ruta { get; set; }

        public string? Link { get; set; }
    }
}
