using Entity.Models;
using Microsoft.EntityFrameworkCore;
namespace Entity.Entity
{
    public class EntityDbContext:DbContext
    {
        public EntityDbContext(DbContextOptions options) : base(options)
        { 
             
        }
        public DbSet<Employee> EmployeeTable { get; set; }


    }
}
