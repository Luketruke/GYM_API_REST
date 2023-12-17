using GYM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GYM.Infrastructure.Data
{
    public class GymContext : DbContext
    {
        public GymContext()
        {
        }

        public GymContext(DbContextOptions<GymContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Dojo> Dojos { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Fighter> Fighters { get; set; }
        public virtual DbSet<Fight> Fights { get; set; }
        public virtual DbSet<Locality> Localities { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Security> Securities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}