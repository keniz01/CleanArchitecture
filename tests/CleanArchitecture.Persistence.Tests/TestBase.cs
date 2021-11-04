using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Tests
{
    public class TestBase
    {
        public static DatabaseContext Context
        {
            get
            {
                var options = new DbContextOptionsBuilder<DatabaseContext>()
                    .UseSqlServer("Server=(local);Database=ContinentContext;Trusted_Connection=True;")
                    .EnableDetailedErrors()
                    .Options;
                var context = new DatabaseContext(options);
                return context;
            }
        }
    }
}