using Making_Sense_Project_API.Model.Class;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Making_Sense_Project_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars {get;set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
    }
}
