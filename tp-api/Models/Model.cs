using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Models;
namespace Models
{
    public class BloggingContext : DbContext
    {        
        public DbSet<Cliente> Clientes { get; set; }

        // https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=iaew.db");
        }
    }
}