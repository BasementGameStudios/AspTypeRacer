using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AspTypeRacer.Models
{
    public class SimpleDbContext : DbContext
    {
         
        public SimpleDbContext(){ }

        public SimpleDbContext(DbContextOptions<SimpleDbContext> options):base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Set the filename of the database to be created
            optionsBuilder.UseSqlite("Data Source=testdb.sqlite");
        }

        public DbSet<Customer> Customer {get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Define the Table(s) and References to be created automatically
            modelBuilder.Entity<Customer>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.Property(e => e.Id).IsRequired();
                b.Property(e => e.Name).IsRequired().HasMaxLength(255);
                b.ToTable("Customer");
            });
        }

    }
}
