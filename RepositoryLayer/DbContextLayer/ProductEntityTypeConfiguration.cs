using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DbContextLayer
{
    internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne<Category>(c => c.Category)
                   .WithMany(p => p.Products)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasForeignKey(c => c.CategoryID);
        }
    }
}
