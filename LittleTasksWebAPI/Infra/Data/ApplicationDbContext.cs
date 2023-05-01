using LittleTasksWebAPI.Domain.Profiles;
using LittleTasksWebAPI.Domain.Tasks;
using LittleTasksWebAPI.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Task = LittleTasksWebAPI.Domain.Tasks.Task;

namespace LittleTasksWebAPI.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<ResponsableDependent> ResponsableDependents { get; set; }
        public DbSet<Recompense> Recompenses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Profile configs
            modelBuilder.Entity<Profile>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<Profile>()
                .Property(p => p.Description)
                .IsRequired();


            // User configs
            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.ProfileId)
                .IsRequired();
        }
    }
}
