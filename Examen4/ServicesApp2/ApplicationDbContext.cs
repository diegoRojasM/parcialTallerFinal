using Examen3.ServiceApp;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Equipo> Equipos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
}