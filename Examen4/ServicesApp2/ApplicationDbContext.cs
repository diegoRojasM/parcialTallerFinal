using Examen3.ServiceApp2;
using Microsoft.EntityFrameworkCore;

namespace Examen3.ServiceApp2
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuración de la relación entre Event y User
            builder.Entity<Evento>()
                .HasOne(e => e.Creador)
                .WithMany(u => u.EventosCreados)
                .HasForeignKey(e => e.IdCreador);
        }
        
        
    }
}