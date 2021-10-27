using Microsoft.EntityFrameworkCore;
namespace DotnetBakery.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}

        public DbSet<Baker> Bakers {get; set;}

        public DbSet<Bread> Breads {get; set;}
    }
}

/**

ORM === "Object Relational Mapper"

Does all the SQL for you


*/