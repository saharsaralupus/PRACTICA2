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

            modelBuilder.Entity<ActivityResource>()
                .HasOne(ar => ar.Resources)
                .WithMany()
                .HasForeignKey(ar => ar.ResourceId)
                .OnDelete(DeleteBehavior.Cascade); // Esto especifica eliminación en cascada

            modelBuilder.Entity<ActivityResource>()
                .HasOne(ar => ar.Activities)
                .WithMany()
                .HasForeignKey(ar => ar.ActivityId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
