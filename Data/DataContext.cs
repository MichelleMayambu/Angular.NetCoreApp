
using Angular.NetCoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular.NetCoreApp.Data
{
    public class DataContext : DbContext
    {
      public DataContext(DbContextOptions<DataContext> options) : base(options){

        }
       public DbSet<Values> Values { get; set; }

       public DbSet<User> Users {get; set;}
    }
}