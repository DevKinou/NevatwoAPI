﻿using Microsoft.EntityFrameworkCore;
using NevatwoAPI.BDD.Model;
using NLog;

namespace NevatwoAPI.BDD
{
    public class NevaTwoDbContext : DbContext
    {
        private readonly IConfiguration _config;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //DbSet declarations
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Reponses> Reponses { get; set; }
        public DbSet<Axe> Axe { get; set; }
        public DbSet<Entreprise> Entreprise { get; set; }
        public DbSet<ReponseEntreprise> ReponseEntreprise { get; set; }

        public NevaTwoDbContext(DbContextOptions<NevaTwoDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
