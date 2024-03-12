using Microsoft.EntityFrameworkCore;
using Trabajo; // Asegúrate de incluir el espacio de nombres correcto

namespace Trabajo.Context
{
    public class FestivosContext : DbContext
    {
        public FestivosContext(DbContextOptions<FestivosContext> options) : base(options)
        {
        }

        public DbSet<Festivo> Festivos { get; set; }
        public DbSet<Tipo> Tipos { get; set; } // Cambio de DbSet<Tipo> a DbSet<Tipos>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aquí puedes configurar relaciones o restricciones adicionales si es necesario
        }
    }
}
