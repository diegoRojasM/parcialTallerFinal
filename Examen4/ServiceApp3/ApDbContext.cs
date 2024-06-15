using Microsoft.EntityFrameworkCore;
using Examen3.ServiceApp3;

public class ApDbContext : DbContext
{
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Participante> Participantes { get; set; }
    public DbSet<Equipo> Equipos { get; set; }

    public ApDbContext(DbContextOptions<ApDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar la relación entre Evento y Equipo
        modelBuilder.Entity<Evento>()
            .HasMany(e => e.Equipos)
            .WithMany(e => e.Eventos)
            .UsingEntity<Dictionary<string, object>>(
                "EventoEquipo",
                j => j.HasOne<Equipo>().WithMany().HasForeignKey("EquipoId"),
                j => j.HasOne<Evento>().WithMany().HasForeignKey("EventoId"));


        // modelBuilder.Entity<Evento>().HasKey(e => e.Id);
        // modelBuilder.Entity<Participante>().HasKey(p => p.Id);
        // modelBuilder.Entity<Equipo>().HasKey(e => e.Id);

        // modelBuilder.Entity<Evento>()
        //     .HasMany(e => e.Participantes)
        //     .WithOne()
        //     .HasForeignKey(p => p.EventoId);

        // modelBuilder.Entity<Evento>()
        //     .HasMany(e => e.Equipos)
        //     .WithOne()
        //     .HasForeignKey(e => e.EventoId);



        //         modelBuilder.Entity<Evento>()
        //     .HasMany(e => e.Equipos)
        //     .WithMany();

        // modelBuilder.Entity<Evento>()
        //     .HasMany(e => e.Participantes)
        //     .WithMany();
    }
}
