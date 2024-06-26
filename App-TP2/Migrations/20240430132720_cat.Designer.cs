﻿// <auto-generated />
using App_TP2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App_TP2.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240430132720_cat")]
    partial class cat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App_TP2.Models.Categorie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("categorie");
                });

            modelBuilder.Entity("App_TP2.Models.SousCategorie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Categorieid")
                        .HasColumnType("int");

                    b.Property<string>("nomCat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Categorieid");

                    b.ToTable("souscategories");
                });

            modelBuilder.Entity("App_TP2.Models.SousCategorie", b =>
                {
                    b.HasOne("App_TP2.Models.Categorie", "Categorie")
                        .WithMany("SousCategories")
                        .HasForeignKey("Categorieid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("App_TP2.Models.Categorie", b =>
                {
                    b.Navigation("SousCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
