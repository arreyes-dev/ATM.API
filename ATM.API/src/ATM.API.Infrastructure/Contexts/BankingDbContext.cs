using ATM.API.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.API.Infrastructure.Contexts
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración del modelo
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.DNI).IsRequired().HasMaxLength(20);
                entity.HasIndex(c => c.DNI).IsUnique();
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.LastName).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.AccountNumber).IsRequired();
                entity.HasIndex(b => b.AccountNumber).IsUnique();
                entity.Property(b => b.Balance).HasColumnType("decimal(18,2)").IsRequired();

                // Relación con Customer
                entity.HasOne(b => b.Customer)
                      .WithMany(c => c.BankAccounts)
                      .HasForeignKey(b => b.CustomerId);
            });
        }
    }
}
