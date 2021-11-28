﻿// <auto-generated />
using System;
using ConsoleApp1.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleApp1.Migrations
{
    [DbContext(typeof(ViaDBContext))]
    [Migration("20211102144205_1_bookEdit")]
    partial class _1_bookEdit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0-rc.2.21480.5");

            modelBuilder.Entity("ConsoleApp1.Model.Authors", b =>
                {
                    b.Property<int>("AuthorsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FristName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorsId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ConsoleApp1.Model.Books", b =>
                {
                    b.Property<int>("ISBN")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalPages")
                        .HasColumnType("INTEGER");

                    b.HasKey("ISBN");

                    b.HasIndex("AuthorsId");

                    b.HasIndex("GenresId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ConsoleApp1.Model.Genres", b =>
                {
                    b.Property<int>("GenresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GenresId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ConsoleApp1.Model.Books", b =>
                {
                    b.HasOne("ConsoleApp1.Model.Authors", "author")
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleApp1.Model.Genres", "genre")
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("genre");
                });
#pragma warning restore 612, 618
        }
    }
}