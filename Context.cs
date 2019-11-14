using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace TaskDB.MVC
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions options):base(options){}
        
        public DbSet<TaskModel> Tasks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}