using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PjAlexandreBortoli.Models;

namespace PjAlexandreBortoli.Data
{
    public class AppDbContext :
        IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Medico>? Medicos { get; set; }
        public DbSet<Pacient>? Pacients { get; set; }

    }
}