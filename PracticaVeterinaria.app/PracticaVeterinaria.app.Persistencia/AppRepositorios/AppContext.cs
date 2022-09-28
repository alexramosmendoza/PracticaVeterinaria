using Microsoft.EntityFrameworkCore;

using PracticaVeterinaria.app.Dominio;
using PracticaVeterinaria.app.Persistencia.AppRepositorios;

namespace PracticaVeterinaria.app.Persistencia
{
    public class AppContext : DbContext
    {

        public DbSet<HistoriaClinica> historiasclinicas { get; set; }
        public DbSet<Mascota> mascotas { get; set; }
        public DbSet<Propietario> propietarios { get; set; }
        public DbSet<Veterinario> veterinarios { get; set; }
        public DbSet<Visita> visitas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                .UseSqlServer("Data Source =DESKTOP-3PFDA0C; Initial Catalog = PracticaVeterinaria.Data;Trusted_Connection=True; ");
            }
        }
    }
}

