﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecenzjeFilmowe.Server.DataAccess;

#nullable disable

namespace RecenzjeFilmowe.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240621215407_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RecenzjeFilmowe.Server.DataAccess.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Czas")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Premiera")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Rezyseria")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Tytul")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Zdjecie")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Filmy");
                });

            modelBuilder.Entity("RecenzjeFilmowe.Server.DataAccess.Entities.Recenzja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.Property<string>("Tekst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Recenzje");
                });

            modelBuilder.Entity("RecenzjeFilmowe.Server.DataAccess.Entities.Recenzja", b =>
                {
                    b.HasOne("RecenzjeFilmowe.Server.DataAccess.Entities.Film", "Film")
                        .WithMany("Recenzje")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("RecenzjeFilmowe.Server.DataAccess.Entities.Film", b =>
                {
                    b.Navigation("Recenzje");
                });
#pragma warning restore 612, 618
        }
    }
}
