using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DAL.Entities;

namespace Library.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<UserInfo> Users { get; set; }
        public DbSet<Edition> Edtions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(c => c.Authors)
                .WithMany(s => s.Books)
                .UsingEntity(j => j.ToTable("authorbook"));

            modelBuilder.Entity<Book>()
                .HasMany(c => c.Editions)
                .WithMany(s => s.Books)
                .UsingEntity(j => j.ToTable("editionbook"));

            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Dmitry",
                    LastName = "Kulikov",
                    Role = "user",
                    Email = "dima.kulikov1993@gmail.com",
                    Username = "Dima_kulikov1993",
                    Password = "Dima_kulikov1993"
                },
                new UserInfo
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Dmitry",
                    LastName = "Kazin",
                    Role = "user",
                    Email = "Norman1994@mail.ru",
                    Username = "Norman1994",
                    Password = "Dima_kazin1994"
                },
                new UserInfo
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Elena",
                    LastName = "Posypkina",
                    Role = "admin",
                    Email = "burlis@mail.ru",
                    Username = "Burlis",
                    Password = "Burlis1994"
                }
            );

            Guid sorokinsId = Guid.NewGuid();
            Guid sorokinsBook1Id = Guid.NewGuid();
            Guid sorokinsBook2Id = Guid.NewGuid();

            //Author sorokin = new Author
            //{
            //    Id = sorokinsId,
            //    FirstName = "Vladimir",
            //    LastName = "Sorokin",
            //};
            //Book sorokinsBook1 = new Book
            //{
            //    Id = sorokinsBook1Id,
            //    Name = "Goluboe Salo"
            //};
            //Book sorokinsBook2 = new Book
            //{
            //    Id = sorokinsBook2Id,
            //    Name = "Norma"
            //};

            //modelBuilder.Entity<Author>().HasData( sorokin );
            //modelBuilder.Entity<Book>().HasData(sorokinsBook1, sorokinsBook2);
        }
    }
}