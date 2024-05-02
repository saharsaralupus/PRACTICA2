using Investigation.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Investigation.API.Data

{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Investigator> Investigators { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<InvestigatorProject> InvestigatorProyects { get; set; }
        public DbSet<ActivityResource> ActivityResources { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActivityResource>()
                .HasOne(x => x.Resources)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade); // Esto especifica eliminación en cascada

            modelBuilder.Entity<ActivityResource>()
                .HasOne(x => x.Activities)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InvestigatorProject>()
                .HasOne(x => x.Investigators)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade); // Esto especifica eliminación en cascada

            modelBuilder.Entity<InvestigatorProject>()
                .HasOne(x => x.Projects)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Activity>()
                .HasOne(x => x.Projects)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Publication>()
             .HasOne(x => x.Projects)
             .WithMany()
             .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Activity>()
              .HasOne(a => a.Projects)
              .WithMany(p => p.Activities)
              .HasForeignKey(a => a.ProjectId);

            modelBuilder.Entity<Publication>()
              .HasOne(a => a.Projects)
              .WithMany(p => p.Publications)
              .HasForeignKey(a => a.ProjectId);
        }

    }
}
