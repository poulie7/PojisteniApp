using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PojisteniApp.Models;

namespace PojisteniApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pojistenec> Pojistenec { get; set; }
        public DbSet<Pojisteni> Pojisteni { get; set; }

        public DbSet<Pojisteni> PojisteniPojistenec { get; set; }

        public DbSet<PojisteniApp.Models.Conn>? Conn { get; set; }



    }
}