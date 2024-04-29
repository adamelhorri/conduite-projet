using System.ComponentModel;
using System.Data;

using Microsoft.EntityFrameworkCore;
namespace DistributionAPI.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) {
        }
        public DbSet<Question> Questions =>Set<Question>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Answer> Answers => Set<Answer>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<Video> Videos => Set<Videos>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Question>().ToTable("question");
            builder.Entity<Admin>().ToTable("admin");
            builder.Entity<User>().ToTable("user");
            builder.Entity<Video>().ToTable("videos")
            builder.Entity<Answer>()
               .HasOne(a => a.question)
               .WithMany()
               .HasForeignKey(a => a.question_id) // Ensure this matches the actual foreign key column name in your database
               .HasConstraintName("FK_Answer_Question");
        }
       

    
}
}
