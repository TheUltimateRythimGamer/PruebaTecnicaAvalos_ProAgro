using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string conn = "Server=USER1154-PC;Database=PruebaAvalos;Trusted_Connection=True;TrustServerCertificate=True;";
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(conn);
        //    }
        //}

        public DbSet<Location> Locations { get; set; }

    }
}
