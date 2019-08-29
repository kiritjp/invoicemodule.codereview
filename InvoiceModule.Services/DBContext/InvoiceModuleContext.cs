using InvoiceModule.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceModule.Services.DBContext
{
    public class InvoiceModuleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=test;Database=assessment;User Id=sa;Password=ddddddd;");
        }

        public DbSet<Users> users { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<MPDetails> mpDetails { get; set; }
        public DbSet<RGDetails> rgDetails { get; set; }
    }
}
