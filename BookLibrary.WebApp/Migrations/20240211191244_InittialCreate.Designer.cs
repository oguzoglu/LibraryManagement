﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookLibrary.WebApp.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20240211191244_InittialCreate")]
    partial class InittialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Booklibrary")
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("domain.Aggregates.Author.Author", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.HasKey("Id");

                    b.ToTable("authors", "Booklibrary");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        },
                        new
                        {
                            Id = 3
                        });
                });

            modelBuilder.Entity("domain.Aggregates.Book.Book", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer")
                        .HasColumnName("author_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("boolean")
                        .HasColumnName("is_returned");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("books", "Booklibrary");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CategoryId = 1,
                            ImageUrl = "1.jfif",
                            IsReturned = false,
                            Name = "İnce Memed 1"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            CategoryId = 1,
                            ImageUrl = "2.jfif",
                            IsReturned = true,
                            Name = "Yılanı Öldürseler"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            CategoryId = 2,
                            ImageUrl = "3.jfif",
                            IsReturned = true,
                            Name = "Mausmiyet Müzesi"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            CategoryId = 2,
                            ImageUrl = "4.jpg",
                            IsReturned = true,
                            Name = "Kırmızı Saçlı Kadın"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 3,
                            CategoryId = 2,
                            ImageUrl = "5.jpg",
                            IsReturned = true,
                            Name = "Tutunamayanlar"
                        },
                        new
                        {
                            Id = 6,
                            AuthorId = 3,
                            CategoryId = 2,
                            ImageUrl = "6.jpg",
                            IsReturned = true,
                            Name = "Tehlikeli Oyunlar"
                        },
                        new
                        {
                            Id = 7,
                            AuthorId = 3,
                            CategoryId = 2,
                            ImageUrl = "7.jpg",
                            IsReturned = true,
                            Name = "EylemBilim"
                        });
                });

            modelBuilder.Entity("domain.Aggregates.Category.Category", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("categories", "Booklibrary");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Novel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Science"
                        });
                });

            modelBuilder.Entity("domain.Aggregates.Checkout.Checkout", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<string>("Borrower")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("borrower");

                    b.Property<DateTime?>("EndTime")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_time");

                    b.Property<DateTime>("StartTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 2, 11, 19, 12, 40, 396, DateTimeKind.Utc).AddTicks(7508))
                        .HasColumnName("start_time");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("checkouts", "Booklibrary");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            Borrower = "Kayıhan Nedim",
                            EndTime = new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1630),
                            StartTime = new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1628)
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            Borrower = "Emine Münevver",
                            EndTime = new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1639),
                            StartTime = new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1639)
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            Borrower = "Fatma Özlem",
                            EndTime = new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1642),
                            StartTime = new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1642)
                        },
                        new
                        {
                            Id = 4,
                            BookId = 1,
                            Borrower = "Emre Ayberk",
                            EndTime = new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1644),
                            StartTime = new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1644)
                        });
                });

            modelBuilder.Entity("domain.Aggregates.Author.Author", b =>
                {
                    b.OwnsOne("domain.Aggregates.Author.AuthorName", "AuthorName", b1 =>
                        {
                            b1.Property<int>("AuthorId")
                                .HasColumnType("integer");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("last_name");

                            b1.HasKey("AuthorId");

                            b1.ToTable("authors", "Booklibrary");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");

                            b1.HasData(
                                new
                                {
                                    AuthorId = 1,
                                    FirstName = "Yaşar",
                                    LastName = "Kemal"
                                },
                                new
                                {
                                    AuthorId = 2,
                                    FirstName = "Orhan",
                                    LastName = "Pamuk"
                                },
                                new
                                {
                                    AuthorId = 3,
                                    FirstName = "Oğuz",
                                    LastName = "Atay"
                                });
                        });

                    b.Navigation("AuthorName")
                        .IsRequired();
                });

            modelBuilder.Entity("domain.Aggregates.Book.Book", b =>
                {
                    b.HasOne("domain.Aggregates.Author.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Books_Authors");

                    b.HasOne("domain.Aggregates.Category.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Books_Categories");

                    b.Navigation("Author");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("domain.Aggregates.Checkout.Checkout", b =>
                {
                    b.HasOne("domain.Aggregates.Book.Book", "Book")
                        .WithMany("Checkouts")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("domain.Aggregates.Author.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("domain.Aggregates.Book.Book", b =>
                {
                    b.Navigation("Checkouts");
                });

            modelBuilder.Entity("domain.Aggregates.Category.Category", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
