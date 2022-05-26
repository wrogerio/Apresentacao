﻿// <auto-generated />
using System;
using Memory.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Memory.Infra.Migrations
{
    [DbContext(typeof(MemoryContext))]
    partial class MemoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Memory.Domain.Entities.Annotation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<int>("Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("tbAnnotations");
                });

            modelBuilder.Entity("Memory.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("nvarchar(700)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.ToTable("tbCategories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4a489c39-9565-455c-8df4-1de0083755b2"),
                            CategoryName = "Solid",
                            CreatedAt = new DateTime(2022, 5, 24, 13, 26, 22, 509, DateTimeKind.Local).AddTicks(2854),
                            Description = "Best practice do develop",
                            UpdatedAt = new DateTime(2022, 5, 24, 13, 26, 22, 510, DateTimeKind.Local).AddTicks(1296)
                        });
                });

            modelBuilder.Entity("Memory.Domain.Entities.Annotation", b =>
                {
                    b.HasOne("Memory.Domain.Entities.Category", "Category")
                        .WithMany("Annotations")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Memory.Domain.Entities.Category", b =>
                {
                    b.Navigation("Annotations");
                });
#pragma warning restore 612, 618
        }
    }
}
