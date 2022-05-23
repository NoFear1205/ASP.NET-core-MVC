using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DbContextLayer;
using RepositoryLayer.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions con):base(con)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Product>()
                        .HasOne<Category>(c => c.Category)
                        .WithMany(p => p.Products)
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasForeignKey(c => c.CategoryID);*/
            new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());
            modelBuilder.Seed();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
