using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspTypeRacer.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

    }

    public class CustomerDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
