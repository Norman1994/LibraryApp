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
    [Migration("20230405080705_AddSorokinsSeedData2")]
    partial class AddSorokinsSeedData2
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("da5368d8-7225-4fb0-b7b4-9db8280aee00"),
                            FirstName = "Vladimir",
                            LastName = "Sorokin"
                        });
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("7b514a34-976f-4986-a0d4-dc2a82bcf9c8"),
                            Name = "Goluboe Salo",
                            PageCount = 0,
                            Rating = 0
                        },
                        new
                        {
                            Id = new Guid("e4006af1-32b1-4160-9ee5-f5fe6f0d5ccd"),
                            Name = "Norma",
                            PageCount = 0,
                            Rating = 0
                        });
                });

            modelBuilder.Entity("Library.DAL.Entities.Edition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid")
                        .HasColumnName("book_id");

                    b.Property<byte[]>("Cover")
                        .HasColumnType("bytea")
                        .HasColumnName("cover");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("IssueYear")
                        .HasColumnType("text")
                        .HasColumnName("issue_year");

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
                            Id = new Guid("b3e60163-f04a-4e7c-a9d6-2778390505bf"),
                            Email = "dima.kulikov1993@gmail.com",
                            FirstName = "Dmitry",
                            LastName = "Kulikov",
                            Password = "Dima_kulikov1993",
                            Role = "user",
                            Username = "Dima_kulikov1993"
                        },
                        new
                        {
                            Id = new Guid("dd80e78c-d377-4a6a-8e39-4f6cb1fe98a5"),
                            Email = "Norman1994@mail.ru",
                            FirstName = "Dmitry",
                            LastName = "Kazin",
                            Password = "Dima_kazin1994",
                            Role = "user",
                            Username = "Norman1994"
                        },
                        new
                        {
                            Id = new Guid("d175d342-d1b8-4408-8262-0ee65f60208a"),
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
#pragma warning restore 612, 618
        }
    }
}
