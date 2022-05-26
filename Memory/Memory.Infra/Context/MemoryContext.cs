using Memory.Domain.Entities;
using Memory.Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Infra.Context
{
    public class MemoryContext : DbContext
    {
        public DbSet<Category> tbCategories { get; set; }
        public DbSet<Annotation> tbAnnotations { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.; Initial Catalog=MemoryDb; user id=sa; password=sa123@123");
            optionsBuilder.UseLazyLoadingProxies();
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new AnnotationConfig());
        }
    }
}
