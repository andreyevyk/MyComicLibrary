using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyComicLibrary.Models;

namespace MyComicLibrary.Models
{
    public partial class MyComicContext : DbContext
    {
        public MyComicContext(DbContextOptions<MyComicContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=MyComic;Uid=root;Pwd=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            modelBuilder.Ignore<CreatorSearch>();
        }

        public DbSet<MyComicLibrary.Models.Character> Character { get; set; }

        public DbSet<MyComicLibrary.Models.Creator> Creator { get; set; }

        public DbSet<MyComicLibrary.Models.Comic> Comic { get; set; }

    }
}
