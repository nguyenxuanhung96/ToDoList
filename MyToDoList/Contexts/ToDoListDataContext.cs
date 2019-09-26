using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyToDoList.Tables;

namespace MyToDoList.Contexts
{
    public class ToDoListDataContext : BaseContext
    {
        public static readonly ILoggerFactory loggerFactory = new LoggerFactory().AddDebug();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();

            modelBuilder.Entity<ToDo>()
                .HasOne(p => p.Category)
                .WithMany(t => t.ToDos)
                .HasForeignKey(t => t.CategoryID);

            modelBuilder.Entity<Category>()
                .HasMany(p => p.ToDos)
                .WithOne(p => p.Category)
                .HasForeignKey(t => t.CategoryID);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
    }
}
