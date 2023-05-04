﻿// <auto-generated />
using System;
using Library.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Library.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230419074517_BookEditionMigration")]
    partial class BookEditionMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<Guid>("AuthorsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("authorbook");
                });

            modelBuilder.Entity("BookEdition", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EditionsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "EditionsId");

                    b.HasIndex("EditionsId");

                    b.ToTable("editionbook");
                });

            modelBuilder.Entity("Library.DAL.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("Id");

                    b.ToTable("author", "public");
                });

            modelBuilder.Entity("Library.DAL.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Annotation")
                        .HasColumnType("text")
                        .HasColumnName("annotation");

                    b.Property<byte[]>("Cover")
                        .HasColumnType("bytea")
                        .HasColumnName("cover");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("IssueYear")
                        .HasColumnType("text")
                        .HasColumnName("issue_year");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("PageCount")
                        .HasColumnType("integer")
                        .HasColumnName("page_count");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.HasKey("Id");

                    b.ToTable("book", "public");
                });

            modelBuilder.Entity("Library.DAL.Entities.Edition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<byte[]>("Cover")
                        .HasColumnType("bytea")
                        .HasColumnName("cover");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("IssueYear")
                        .HasColumnType("text")
                        .HasColumnName("issue_year");

                    b.Property<string>("Publisher")
                        .HasColumnType("text")
                        .HasColumnName("publisher");

                    b.HasKey("Id");

                    b.ToTable("edition", "public");
                });

            modelBuilder.Entity("Library.DAL.Entities.UserInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<string>("Username")
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4c7825cb-5034-4479-9464-70142063f413"),
                            Email = "dima.kulikov1993@gmail.com",
                            FirstName = "Dmitry",
                            LastName = "Kulikov",
                            Password = "Dima_kulikov1993",
                            Role = "user",
                            Username = "Dima_kulikov1993"
                        },
                        new
                        {
                            Id = new Guid("685486b3-57eb-4bdc-b481-c5724a49a139"),
                            Email = "Norman1994@mail.ru",
                            FirstName = "Dmitry",
                            LastName = "Kazin",
                            Password = "Dima_kazin1994",
                            Role = "user",
                            Username = "Norman1994"
                        },
                        new
                        {
                            Id = new Guid("aeae0fb6-1a3b-4ff8-9500-54b37064364f"),
                            Email = "burlis@mail.ru",
                            FirstName = "Elena",
                            LastName = "Posypkina",
                            Password = "Burlis1994",
                            Role = "admin",
                            Username = "Burlis"
                        });
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Library.DAL.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.DAL.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookEdition", b =>
                {
                    b.HasOne("Library.DAL.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.DAL.Entities.Edition", null)
                        .WithMany()
                        .HasForeignKey("EditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}