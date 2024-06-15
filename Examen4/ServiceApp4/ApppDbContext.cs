using Examen3.ServiceApp4;

using Microsoft.EntityFrameworkCore;

namespace Examen3.ServiceApp4
{
    public class ApppDbContext: DbContext
    {
        public ApppDbContext(DbContextOptions<ApppDbContext> options)
            :base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }
    }
}