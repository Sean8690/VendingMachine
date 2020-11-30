using Microsoft.EntityFrameworkCore;
using VendingMachine.API.Models;

namespace VendingMachine.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Value> ValuesContent {get; set;}
        public DbSet<Can> Cans {get; set;}
        public DbSet<Payment> Payments {get; set;}
    }
}