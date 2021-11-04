using CleanArchitecture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Tests
{
    public class TestBase
    {
        public DatabaseContext Context
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