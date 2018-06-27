using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Models;
namespace Models
{
    public class Context : DbContext
    {        
        //public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Reserva> Reservas { get; set; }


        // https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
    }
}