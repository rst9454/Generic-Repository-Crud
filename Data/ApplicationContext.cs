using Microsoft.EntityFrameworkCore;
using Using_GenericRepository_CrudOperation.Models;

namespace Using_GenericRepository_CrudOperation.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<tblEmployee> Employee { get; set; }
    }
}
