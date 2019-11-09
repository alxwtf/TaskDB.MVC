using Microsoft.EntityFrameworkCore;
namespace TaskDB.MVC
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options):base(options){}
        public DbSet<TaskModel> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskMap());
        }
    }
}