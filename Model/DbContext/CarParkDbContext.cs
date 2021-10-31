using CoreApp.Model.Entity;
using CoreApp.Model.SeedData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp.Model
{
    public class CarParkDbContext: DbContext
    {
        public CarParkDbContext() : base()
        {

        }

        public CarParkDbContext(DbContextOptions<CarParkDbContext> options): base(options)
        {

        }

        public DbSet<BookingOffice> BookingOffices { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Parkinglot> Parkinglots { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataSeeder.Seed(modelBuilder);
        }
    }
}
