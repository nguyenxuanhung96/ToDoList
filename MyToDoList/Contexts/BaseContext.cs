using Microsoft.EntityFrameworkCore;

namespace MyToDoList.Contexts
{
    public class BaseContext : DbContext
    {
        protected BaseContext()
            : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DEV-HUNGNX;Database=MyToDoList;User id=sa;Password=1234567;Integrated Security=True");
        }
    }
}
