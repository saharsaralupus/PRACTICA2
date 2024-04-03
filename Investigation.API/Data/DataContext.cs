using Investigation.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Investigation.API.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Proyect> Proyects { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Investigator> Investigators { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<InvestigatorProyect> InvestigatorProyects { get; set; }
        public DbSet<ActivityResource> ActivityResources { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
