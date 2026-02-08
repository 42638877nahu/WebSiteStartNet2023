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
        public DbSet<WebSiteStartNet2023.Models.NivelOral> NivelOral { get; set; }
        public DbSet<WebSiteStartNet2023.Models.NivelEscrito> NivelEscrito { get; set; }
        public DbSet<WebSiteStartNet2023.Models.NivelLectura> NivelLectura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Provincia>().HasData(
                new Provincia { Id = 1, Nombre = "Buenos Aires" },
                new Provincia { Id = 2, Nombre = "Catamarca" },
                new Provincia { Id = 3, Nombre = "Chaco" },
                new Provincia { Id = 4, Nombre = "Chubut" },
                new Provincia { Id = 5, Nombre = "Córdoba" },
                new Provincia { Id = 6, Nombre = "Corrientes" },
                new Provincia { Id = 7, Nombre = "Entre Ríos" },
                new Provincia { Id = 8, Nombre = "Formosa" },
                new Provincia { Id = 9, Nombre = "Jujuy" },
                new Provincia { Id = 10, Nombre = "La Pampa" },
                new Provincia { Id = 11, Nombre = "La Rioja" },
                new Provincia { Id = 12, Nombre = "Mendoza" },
                new Provincia { Id = 13, Nombre = "Misiones" },
                new Provincia { Id = 14, Nombre = "Neuquén" },
                new Provincia { Id = 15, Nombre = "Río Negro" },
                new Provincia { Id = 16, Nombre = "Salta" },
                new Provincia { Id = 17, Nombre = "San Juan" },
                new Provincia { Id = 18, Nombre = "San Luis" },
                new Provincia { Id = 19, Nombre = "Santa Cruz" },
                new Provincia { Id = 20, Nombre = "Santa Fe" },
                new Provincia { Id = 21, Nombre = "Santiago del Estero" },
                new Provincia { Id = 22, Nombre = "Tierra del Fuego" },
                new Provincia { Id = 23, Nombre = "Tucumán" },
                new Provincia { Id = 24, Nombre = "Ciudad Autónoma de Buenos Aires" }
            );

            modelBuilder.Entity<Localidad>().HasData(

            // Buenos Aires
            new Localidad { Id = 1, Nombre = "La Plata", CodigoPostal = "1900", ProvinciaId = 1 },
            new Localidad { Id = 2, Nombre = "Mar del Plata", CodigoPostal = "7600", ProvinciaId = 1 },
            new Localidad { Id = 3, Nombre = "Bahía Blanca", CodigoPostal = "8000", ProvinciaId = 1 },
            new Localidad { Id = 4, Nombre = "Tandil", CodigoPostal = "7000", ProvinciaId = 1 },
            new Localidad { Id = 5, Nombre = "San Isidro", CodigoPostal = "1642", ProvinciaId = 1 },

            // Catamarca
            new Localidad { Id = 6, Nombre = "San Fernando del Valle", CodigoPostal = "4700", ProvinciaId = 2 },
            new Localidad { Id = 7, Nombre = "Belén", CodigoPostal = "4750", ProvinciaId = 2 },
            new Localidad { Id = 8, Nombre = "Andalgalá", CodigoPostal = "4740", ProvinciaId = 2 },
            new Localidad { Id = 9, Nombre = "Tinogasta", CodigoPostal = "5340", ProvinciaId = 2 },
            new Localidad { Id = 10, Nombre = "Recreo", CodigoPostal = "4715", ProvinciaId = 2 },

            // Chaco
            new Localidad { Id = 11, Nombre = "Resistencia", CodigoPostal = "3500", ProvinciaId = 3 },
            new Localidad { Id = 12, Nombre = "Presidencia Roque Sáenz Peña", CodigoPostal = "3700", ProvinciaId = 3 },
            new Localidad { Id = 13, Nombre = "Villa Ángela", CodigoPostal = "3540", ProvinciaId = 3 },
            new Localidad { Id = 14, Nombre = "Charata", CodigoPostal = "3730", ProvinciaId = 3 },
            new Localidad { Id = 15, Nombre = "General San Martín", CodigoPostal = "3509", ProvinciaId = 3 },

            // Chubut
            new Localidad { Id = 16, Nombre = "Rawson", CodigoPostal = "9103", ProvinciaId = 4 },
            new Localidad { Id = 17, Nombre = "Trelew", CodigoPostal = "9100", ProvinciaId = 4 },
            new Localidad { Id = 18, Nombre = "Puerto Madryn", CodigoPostal = "9120", ProvinciaId = 4 },
            new Localidad { Id = 19, Nombre = "Comodoro Rivadavia", CodigoPostal = "9000", ProvinciaId = 4 },
            new Localidad { Id = 20, Nombre = "Esquel", CodigoPostal = "9200", ProvinciaId = 4 },

            // Córdoba
            new Localidad { Id = 21, Nombre = "Córdoba Capital", CodigoPostal = "5000", ProvinciaId = 5 },
            new Localidad { Id = 22, Nombre = "Villa Carlos Paz", CodigoPostal = "5152", ProvinciaId = 5 },
            new Localidad { Id = 23, Nombre = "Río Cuarto", CodigoPostal = "5800", ProvinciaId = 5 },
            new Localidad { Id = 24, Nombre = "San Francisco", CodigoPostal = "2400", ProvinciaId = 5 },
            new Localidad { Id = 25, Nombre = "Villa María", CodigoPostal = "5900", ProvinciaId = 5 },

            // Corrientes
            new Localidad { Id = 26, Nombre = "Corrientes Capital", CodigoPostal = "3400", ProvinciaId = 6 },
            new Localidad { Id = 27, Nombre = "Goya", CodigoPostal = "3450", ProvinciaId = 6 },
            new Localidad { Id = 28, Nombre = "Paso de los Libres", CodigoPostal = "3230", ProvinciaId = 6 },
            new Localidad { Id = 29, Nombre = "Mercedes", CodigoPostal = "3470", ProvinciaId = 6 },
            new Localidad { Id = 30, Nombre = "Ituzaingó", CodigoPostal = "3302", ProvinciaId = 6 },

            // Entre Ríos
            new Localidad { Id = 31, Nombre = "Paraná", CodigoPostal = "3100", ProvinciaId = 7 },
            new Localidad { Id = 32, Nombre = "Concordia", CodigoPostal = "3200", ProvinciaId = 7 },
            new Localidad { Id = 33, Nombre = "Gualeguaychú", CodigoPostal = "2820", ProvinciaId = 7 },
            new Localidad { Id = 34, Nombre = "Concepción del Uruguay", CodigoPostal = "3260", ProvinciaId = 7 },
            new Localidad { Id = 35, Nombre = "Victoria", CodigoPostal = "3153", ProvinciaId = 7 },

            // Formosa
            new Localidad { Id = 36, Nombre = "Formosa Capital", CodigoPostal = "3600", ProvinciaId = 8 },
            new Localidad { Id = 37, Nombre = "Clorinda", CodigoPostal = "3610", ProvinciaId = 8 },
            new Localidad { Id = 38, Nombre = "Pirané", CodigoPostal = "3620", ProvinciaId = 8 },
            new Localidad { Id = 39, Nombre = "Las Lomitas", CodigoPostal = "3630", ProvinciaId = 8 },
            new Localidad { Id = 40, Nombre = "El Colorado", CodigoPostal = "3603", ProvinciaId = 8 },

            // Jujuy
            new Localidad { Id = 41, Nombre = "San Salvador de Jujuy", CodigoPostal = "4600", ProvinciaId = 9 },
            new Localidad { Id = 42, Nombre = "Palpalá", CodigoPostal = "4612", ProvinciaId = 9 },
            new Localidad { Id = 43, Nombre = "Perico", CodigoPostal = "4608", ProvinciaId = 9 },
            new Localidad { Id = 44, Nombre = "Libertador General San Martín", CodigoPostal = "4512", ProvinciaId = 9 },
            new Localidad { Id = 45, Nombre = "La Quiaca", CodigoPostal = "4650", ProvinciaId = 9 },

            // La Pampa
            new Localidad { Id = 46, Nombre = "Santa Rosa", CodigoPostal = "6300", ProvinciaId = 10 },
            new Localidad { Id = 47, Nombre = "General Pico", CodigoPostal = "6360", ProvinciaId = 10 },
            new Localidad { Id = 48, Nombre = "Toay", CodigoPostal = "6303", ProvinciaId = 10 },
            new Localidad { Id = 49, Nombre = "Realicó", CodigoPostal = "6200", ProvinciaId = 10 },
            new Localidad { Id = 50, Nombre = "Victorica", CodigoPostal = "6319", ProvinciaId = 10 },

            // La Rioja
            new Localidad { Id = 51, Nombre = "La Rioja Capital", CodigoPostal = "5300", ProvinciaId = 11 },
            new Localidad { Id = 52, Nombre = "Chilecito", CodigoPostal = "5360", ProvinciaId = 11 },
            new Localidad { Id = 53, Nombre = "Aimogasta", CodigoPostal = "5310", ProvinciaId = 11 },
            new Localidad { Id = 54, Nombre = "Chamical", CodigoPostal = "5380", ProvinciaId = 11 },
            new Localidad { Id = 55, Nombre = "Chepes", CodigoPostal = "5470", ProvinciaId = 11 },

            // Mendoza
            new Localidad { Id = 56, Nombre = "Mendoza Capital", CodigoPostal = "5500", ProvinciaId = 12 },
            new Localidad { Id = 57, Nombre = "San Rafael", CodigoPostal = "5600", ProvinciaId = 12 },
            new Localidad { Id = 58, Nombre = "Godoy Cruz", CodigoPostal = "5501", ProvinciaId = 12 },
            new Localidad { Id = 59, Nombre = "Maipú", CodigoPostal = "5515", ProvinciaId = 12 },
            new Localidad { Id = 60, Nombre = "Luján de Cuyo", CodigoPostal = "5507", ProvinciaId = 12 },

            // Misiones
            new Localidad { Id = 61, Nombre = "Posadas", CodigoPostal = "3300", ProvinciaId = 13 },
            new Localidad { Id = 62, Nombre = "Oberá", CodigoPostal = "3360", ProvinciaId = 13 },
            new Localidad { Id = 63, Nombre = "Eldorado", CodigoPostal = "3380", ProvinciaId = 13 },
            new Localidad { Id = 64, Nombre = "Puerto Iguazú", CodigoPostal = "3370", ProvinciaId = 13 },
            new Localidad { Id = 65, Nombre = "Apóstoles", CodigoPostal = "3350", ProvinciaId = 13 },

            // Neuquén
            new Localidad { Id = 66, Nombre = "Neuquén Capital", CodigoPostal = "8300", ProvinciaId = 14 },
            new Localidad { Id = 67, Nombre = "San Martín de los Andes", CodigoPostal = "8370", ProvinciaId = 14 },
            new Localidad { Id = 68, Nombre = "Villa La Angostura", CodigoPostal = "8407", ProvinciaId = 14 },
            new Localidad { Id = 69, Nombre = "Cutral Có", CodigoPostal = "8322", ProvinciaId = 14 },
            new Localidad { Id = 70, Nombre = "Zapala", CodigoPostal = "8340", ProvinciaId = 14 },

            // Río Negro
            new Localidad { Id = 71, Nombre = "Viedma", CodigoPostal = "8500", ProvinciaId = 15 },
            new Localidad { Id = 72, Nombre = "San Carlos de Bariloche", CodigoPostal = "8400", ProvinciaId = 15 },
            new Localidad { Id = 73, Nombre = "General Roca", CodigoPostal = "8332", ProvinciaId = 15 },
            new Localidad { Id = 74, Nombre = "Cipolletti", CodigoPostal = "8324", ProvinciaId = 15 },
            new Localidad { Id = 75, Nombre = "Villa Regina", CodigoPostal = "8336", ProvinciaId = 15 },

            // Salta
            new Localidad { Id = 76, Nombre = "Salta Capital", CodigoPostal = "4400", ProvinciaId = 16 },
            new Localidad { Id = 77, Nombre = "Tartagal", CodigoPostal = "4560", ProvinciaId = 16 },
            new Localidad { Id = 78, Nombre = "Orán", CodigoPostal = "4530", ProvinciaId = 16 },
            new Localidad { Id = 79, Nombre = "Metán", CodigoPostal = "4440", ProvinciaId = 16 },
            new Localidad { Id = 80, Nombre = "Cafayate", CodigoPostal = "4427", ProvinciaId = 16 },

            // San Juan
            new Localidad { Id = 81, Nombre = "San Juan Capital", CodigoPostal = "5400", ProvinciaId = 17 },
            new Localidad { Id = 82, Nombre = "Rawson", CodigoPostal = "5425", ProvinciaId = 17 },
            new Localidad { Id = 83, Nombre = "Rivadavia", CodigoPostal = "5407", ProvinciaId = 17 },
            new Localidad { Id = 84, Nombre = "Pocito", CodigoPostal = "5429", ProvinciaId = 17 },
            new Localidad { Id = 85, Nombre = "Caucete", CodigoPostal = "5442", ProvinciaId = 17 },

            // San Luis
            new Localidad { Id = 86, Nombre = "San Luis Capital", CodigoPostal = "5700", ProvinciaId = 18 },
            new Localidad { Id = 87, Nombre = "Villa Mercedes", CodigoPostal = "5730", ProvinciaId = 18 },
            new Localidad { Id = 88, Nombre = "Merlo", CodigoPostal = "5881", ProvinciaId = 18 },
            new Localidad { Id = 89, Nombre = "La Punta", CodigoPostal = "5710", ProvinciaId = 18 },
            new Localidad { Id = 90, Nombre = "Quines", CodigoPostal = "5711", ProvinciaId = 18 },

            // Santa Cruz
            new Localidad { Id = 91, Nombre = "Río Gallegos", CodigoPostal = "9400", ProvinciaId = 19 },
            new Localidad { Id = 92, Nombre = "Caleta Olivia", CodigoPostal = "9011", ProvinciaId = 19 },
            new Localidad { Id = 93, Nombre = "El Calafate", CodigoPostal = "9405", ProvinciaId = 19 },
            new Localidad { Id = 94, Nombre = "Puerto Deseado", CodigoPostal = "9050", ProvinciaId = 19 },
            new Localidad { Id = 95, Nombre = "Pico Truncado", CodigoPostal = "9015", ProvinciaId = 19 },

            // Santa Fe
            new Localidad { Id = 96, Nombre = "Rosario", CodigoPostal = "2000", ProvinciaId = 20 },
            new Localidad { Id = 97, Nombre = "Santa Fe Capital", CodigoPostal = "3000", ProvinciaId = 20 },
            new Localidad { Id = 98, Nombre = "Rafaela", CodigoPostal = "2300", ProvinciaId = 20 },
            new Localidad { Id = 99, Nombre = "Venado Tuerto", CodigoPostal = "2600", ProvinciaId = 20 },
            new Localidad { Id = 100, Nombre = "Reconquista", CodigoPostal = "3560", ProvinciaId = 20 },

            // Santiago del Estero
            new Localidad { Id = 101, Nombre = "Santiago del Estero Capital", CodigoPostal = "4200", ProvinciaId = 21 },
            new Localidad { Id = 102, Nombre = "La Banda", CodigoPostal = "4300", ProvinciaId = 21 },
            new Localidad { Id = 103, Nombre = "Termas de Río Hondo", CodigoPostal = "4220", ProvinciaId = 21 },
            new Localidad { Id = 104, Nombre = "Añatuya", CodigoPostal = "3760", ProvinciaId = 21 },
            new Localidad { Id = 105, Nombre = "Frías", CodigoPostal = "4230", ProvinciaId = 21 },

            // Tierra del Fuego
            new Localidad { Id = 106, Nombre = "Ushuaia", CodigoPostal = "9410", ProvinciaId = 22 },
            new Localidad { Id = 107, Nombre = "Río Grande", CodigoPostal = "9420", ProvinciaId = 22 },
            new Localidad { Id = 108, Nombre = "Tolhuin", CodigoPostal = "9421", ProvinciaId = 22 },
            new Localidad { Id = 109, Nombre = "San Sebastián", CodigoPostal = "9425", ProvinciaId = 22 },
            new Localidad { Id = 110, Nombre = "Lago Escondido", CodigoPostal = "9412", ProvinciaId = 22 },

            // Tucumán
            new Localidad { Id = 111, Nombre = "San Miguel de Tucumán", CodigoPostal = "4000", ProvinciaId = 23 },
            new Localidad { Id = 112, Nombre = "Yerba Buena", CodigoPostal = "4107", ProvinciaId = 23 },
            new Localidad { Id = 113, Nombre = "Tafí Viejo", CodigoPostal = "4103", ProvinciaId = 23 },
            new Localidad { Id = 114, Nombre = "Concepción", CodigoPostal = "4146", ProvinciaId = 23 },
            new Localidad { Id = 115, Nombre = "Monteros", CodigoPostal = "4142", ProvinciaId = 23 },

            // CABA
            new Localidad { Id = 116, Nombre = "Palermo", CodigoPostal = "1425", ProvinciaId = 24 },
            new Localidad { Id = 117, Nombre = "Recoleta", CodigoPostal = "1113", ProvinciaId = 24 },
            new Localidad { Id = 118, Nombre = "Caballito", CodigoPostal = "1405", ProvinciaId = 24 },
            new Localidad { Id = 119, Nombre = "Belgrano", CodigoPostal = "1428", ProvinciaId = 24 },
            new Localidad { Id = 120, Nombre = "San Telmo", CodigoPostal = "1068", ProvinciaId = 24 }

            );
        }

    }
}
