using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EF_EX2._1
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<Error> Errors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb;Database = SecondDb; Trusted_connection = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Order>();
            modelBuilder.Ignore<Error>();
            modelBuilder.Entity<Product>().HasAlternateKey(a => a.ProductAlterId);
            modelBuilder.Entity<Product>().Ignore(p=>p.ProductAlterId);

            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnName("ProductId");
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).IsRequired();

            modelBuilder.Entity<User>().Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<User>().Property(p => p.Login).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.Email).IsRequired();

            modelBuilder.Entity<Order>().Property(p => p.Id).HasColumnName("OrderId");
            modelBuilder.Entity<Order>().Property(p=>p.Create).HasColumnType("Date");
            modelBuilder.Entity<Order>().Property(p => p.Update).HasColumnType("Date");
            modelBuilder.Entity<Order>().Property(p => p.Description).IsRequired();
        }
    }

    internal enum StatusCode : int
    {
        Ok = 200,
        NotFound = 404,
        Server = 500
    }

    internal class Error
    {
        public int AlterId { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Request { get; set; }
        public StatusCode Status { get; set; }
    }
}
