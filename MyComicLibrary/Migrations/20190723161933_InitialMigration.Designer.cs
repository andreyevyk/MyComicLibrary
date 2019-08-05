﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyComicLibrary.Models;

namespace MyComicLibrary.Migrations
{
    [DbContext(typeof(MyComicContext))]
    [Migration("20190723161933_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyComicLibrary.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<int>("id_comic");

                    b.HasKey("Id");

                    b.HasIndex("id_comic");

                    b.ToTable("characters");
                });

            modelBuilder.Entity("MyComicLibrary.Models.Comic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description");

                    b.Property<string>("ImageCover")
                        .HasColumnName("image_cover");

                    b.Property<int>("List")
                        .HasColumnName("list");

                    b.Property<int>("PageCount")
                        .HasColumnName("page_count");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.ToTable("comic");
                });

            modelBuilder.Entity("MyComicLibrary.Models.Creator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnName("role");

                    b.Property<int>("id_comic");

                    b.HasKey("Id");

                    b.HasIndex("id_comic");

                    b.ToTable("creator");
                });

            modelBuilder.Entity("MyComicLibrary.Models.Character", b =>
                {
                    b.HasOne("MyComicLibrary.Models.Comic", "Comic")
                        .WithMany("Characters")
                        .HasForeignKey("id_comic")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyComicLibrary.Models.Creator", b =>
                {
                    b.HasOne("MyComicLibrary.Models.Comic", "Comic")
                        .WithMany("Creators")
                        .HasForeignKey("id_comic")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
