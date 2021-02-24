using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saidality.Models
{
    //public class AppDbContext : DbContext
    public class AppDbContext : IdentityDbContext
    {
        private readonly DbContextOptions _options;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options)
        {
            _options = options;
        }

        public DbSet<Pharmcy> Pharmcies { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Locaton> Locaton { get; set; }
        public DbSet<Order> Order { get; set; }
    }
   
}
