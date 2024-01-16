using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebSiteStartNet2023.Models;

namespace WebSiteStartNet2023.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Novedad> Novedades { get; set; }

        public DbSet<CV> CVs { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<RubroCliente> RubrosClientes { get; set; }
    }
}