using Microsoft.EntityFrameworkCore;
using NevatwoAPI.BDD.Model;
using NLog;

namespace NevatwoAPI.BDD
{
    public class NevaTwoDbContext : DbContext
    {
        //DbSet declarations
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Reponses> Reponses { get; set; }
        public DbSet<Axe> Axe { get; set; }
        public DbSet<Entreprise> Entreprise { get; set; }
        public DbSet<ReponseEntreprise> ReponseEntreprise { get; set; }

        public NevaTwoDbContext(DbContextOptions<NevaTwoDbContext> options) : base(options)
        {
        }
    }
}
