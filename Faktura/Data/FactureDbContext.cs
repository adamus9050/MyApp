using Faktura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Faktura.Data
{
    public class FactureDbContext : DbContext
    {
        public DbSet<AdressesCustomers> Adress { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public  DbSet<Kolnierz> Kolnierze { get; set; } = null!;
        public DbSet<Materials> Materialy {get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseSqlServer(@"Server=DESKTOP-MC18DH6;Database=Kami;trusted_connection=true;encrypt=false");

        protected override void OnModelCreating(ModelBuilder modeBuilder)
        {
            modeBuilder.Entity<AdressesCustomers>()
            .Property(x => x.PostCode).HasColumnType("varchar(5)");

            modeBuilder.Entity<AdressesCustomers>()
            .Property(x => x.PostCode).HasMaxLength(5);

            modeBuilder.Entity<AdressesCustomers>()
            .Property(x => x.PostCode).HasColumnName("Post_Code");

            modeBuilder.Entity<Customer>()
                .Property(x => x.PhoneNumber).HasColumnType("varchar(5)");

            modeBuilder.Entity<Customer>()
            .Property(x => x.PhoneNumber).HasMaxLength(11);



            modeBuilder.Entity<Customer>(e =>
            {
                //e.HasOne(x => x.Customer)
                //.WithOne(y => y.Adressess)
                //.HasForeignKey<Customer>(y => y.AdressId);

                e.HasOne(xi => xi.Adressess)
                .WithOne(yi => yi.Customer)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Customer>(yi => yi.AdressId);
            });
        }
    }
}
