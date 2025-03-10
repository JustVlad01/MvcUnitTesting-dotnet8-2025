﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MvcUnitTesting_dotnet8.Models;

#nullable disable

namespace MvcUnitTesting_dotnet8.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20250122164343_initial-books")]
    partial class initialbooks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MvcUnitTesting_dotnet8.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.HasKey("ID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Genre = "Fiction",
                            Name = "Moby Dick",
                            Price = 12.50m
                        },
                        new
                        {
                            ID = 2,
                            Genre = "Fiction",
                            Name = "War and Peace",
                            Price = 17m
                        },
                        new
                        {
                            ID = 3,
                            Genre = "Science Fiction",
                            Name = "Escape from the vortex",
                            Price = 12.50m
                        },
                        new
                        {
                            ID = 4,
                            Genre = "History",
                            Name = "The Battle of the Somme",
                            Price = 22m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
