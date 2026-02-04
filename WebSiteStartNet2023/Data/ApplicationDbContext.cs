using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSiteStartNet2023.Models;

namespace WebSiteStartNet2023.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // EXISTENTES
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Novedad> Novedades { get; set; }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<RubroCliente> RubrosClientes { get; set; }
        public DbSet<PuestoTrabajo> PuestoTrabajos { get; set; }

        // 🔥 NUEVO MÓDULO BOLSA DE TRABAJO
        public DbSet<Postulante> Postulantes { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Localidad> Localidades { get; set; }

        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<NivelConocimiento> NivelesConocimiento { get; set; }

        public DbSet<TecnologiaPostulante> TecnologiasPostulantes { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<IdiomaPostulante> IdiomasPostulantes { get; set; }

        public DbSet<ExperienciaTrabajo> ExperienciasTrabajo { get; set; }
        public DbSet<PuestoTrabajoPostulante> PuestosTrabajoPostulantes { get; set; }
        public DbSet<WebSiteStartNet2023.Models.NivelOral>? NivelOral { get; set; }
        public DbSet<WebSiteStartNet2023.Models.NivelEscrito>? NivelEscrito { get; set; }
        public DbSet<WebSiteStartNet2023.Models.NivelLectura>? NivelLectura { get; set; }
    }
}
