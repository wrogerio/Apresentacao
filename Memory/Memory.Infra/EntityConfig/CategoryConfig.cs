using Memory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Memory.Infra.EntityConfig
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.CategoryName).IsRequired().HasMaxLength(350);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(700);

            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.UpdatedAt).HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasMany(c => c.Annotations).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.HasData( new Category { Id = Guid.NewGuid(), CategoryName = "Solid", Description = "Best practice do develop", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
        }
    }
}
