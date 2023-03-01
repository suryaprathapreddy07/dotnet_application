using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext:DbContext
    {
        //creating constructor to pass a database context option to base class i.e; DbContext
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //creating datasets
        public DbSet<Category> Category { get; set; }
    }
}
