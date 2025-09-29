using Microsoft.EntityFrameworkCore;
using WebApiService.Models.Entities;

namespace WebApiService.Models.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shippers> Shippers { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().ToTable(nameof(Customers), "Sales").HasKey(prop => prop.custid);
            modelBuilder.Entity<Employees>().ToTable(nameof(Employees), "HR").HasKey(prop => prop.empid);
            modelBuilder.Entity<OrderDetails>().HasKey(prop => prop.orderid);
            modelBuilder.Entity<Orders>().ToTable(nameof(Orders), "Sales").HasKey(prop => prop.orderid);
            modelBuilder.Entity<Products>().ToTable(nameof(Products), "Production").HasKey(prop => prop.productid);
            modelBuilder.Entity<Shippers>().ToTable(nameof(Shippers), "Sales").HasKey(prop => prop.shipperid);
        }
    }
}
