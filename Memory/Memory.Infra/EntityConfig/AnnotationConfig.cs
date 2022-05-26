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
    internal class AnnotationConfig : IEntityTypeConfiguration<Annotation>
    {
        public void Configure(EntityTypeBuilder<Annotation> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Order).HasDefaultValue(0);
            builder.Property(c => c.Type).IsRequired().HasMaxLength(70);
            builder.Property(c => c.Tags).IsRequired().HasMaxLength(500);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(700);
            
            builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.UpdatedAt).HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(c => c.Category).WithMany(c => c.Annotations).HasForeignKey(c => c.CategoryId);

        }
    }
}
