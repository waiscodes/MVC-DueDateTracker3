﻿// <auto-generated />
using System;
using LibraryDueDateTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryDueDateTracker.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20201106025339_extentionCountBorrow")]
    partial class extentionCountBorrow
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LibraryDueDateTracker.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(60)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("author");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            BirthDate = new DateTime(1975, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Brandon Sanderson"
                        },
                        new
                        {
                            ID = -2,
                            BirthDate = new DateTime(1973, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Patrick Rothfuss"
                        },
                        new
                        {
                            ID = -3,
                            BirthDate = new DateTime(1955, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeathDate = new DateTime(2001, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Douglas Adams"
                        },
                        new
                        {
                            ID = -4,
                            BirthDate = new DateTime(1946, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Philip Pullman"
                        },
                        new
                        {
                            ID = -5,
                            BirthDate = new DateTime(1965, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Eoin Colfer"
                        });
                });

            modelBuilder.Entity("LibraryDueDateTracker.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID")
                        .HasName("FK_Book_Author");

                    b.ToTable("book");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            AuthorID = -1,
                            PublicationDate = new DateTime(2006, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mistborn"
                        },
                        new
                        {
                            ID = -2,
                            AuthorID = -1,
                            PublicationDate = new DateTime(2010, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Way of Kings"
                        },
                        new
                        {
                            ID = -3,
                            AuthorID = -1,
                            PublicationDate = new DateTime(2010, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Warbreaker"
                        },
                        new
                        {
                            ID = -4,
                            AuthorID = -2,
                            PublicationDate = new DateTime(2007, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Name of the Wind"
                        },
                        new
                        {
                            ID = -5,
                            AuthorID = -2,
                            PublicationDate = new DateTime(2011, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Wise Man's Fear"
                        },
                        new
                        {
                            ID = -6,
                            AuthorID = -2,
                            PublicationDate = new DateTime(2014, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "A Slow Regard for Silent Things"
                        },
                        new
                        {
                            ID = -7,
                            AuthorID = -3,
                            PublicationDate = new DateTime(1978, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Hitchhiker's Guide to the Galaxy"
                        },
                        new
                        {
                            ID = -8,
                            AuthorID = -3,
                            PublicationDate = new DateTime(1980, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Life, the Universe, and Everything"
                        },
                        new
                        {
                            ID = -9,
                            AuthorID = -3,
                            PublicationDate = new DateTime(1980, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "So Long and Thanks for all the Fish"
                        },
                        new
                        {
                            ID = -10,
                            AuthorID = -4,
                            PublicationDate = new DateTime(1995, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Golden Compass"
                        },
                        new
                        {
                            ID = -11,
                            AuthorID = -4,
                            PublicationDate = new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Subtle Knife"
                        },
                        new
                        {
                            ID = -12,
                            AuthorID = -4,
                            PublicationDate = new DateTime(2017, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "La Belle Sauvage"
                        },
                        new
                        {
                            ID = -13,
                            AuthorID = -5,
                            PublicationDate = new DateTime(1997, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Artemis Fowl"
                        },
                        new
                        {
                            ID = -14,
                            AuthorID = -5,
                            PublicationDate = new DateTime(2004, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Airman"
                        },
                        new
                        {
                            ID = -15,
                            AuthorID = -5,
                            PublicationDate = new DateTime(2009, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "And Another Thing..."
                        });
                });

            modelBuilder.Entity("LibraryDueDateTracker.Models.Borrow", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<int>("BookID")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("CheckedOutDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("ExtensionCount")
                        .HasColumnType("int(10)");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("date");

                    b.HasKey("ID");

                    b.HasIndex("BookID")
                        .HasName("FK_Borrow_Book");

                    b.ToTable("borrow");

                    b.HasData(
                        new
                        {
                            ID = -1,
                            BookID = -1,
                            CheckedOutDate = new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 0,
                            ReturnedDate = new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -2,
                            BookID = -2,
                            CheckedOutDate = new DateTime(2020, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 1,
                            ReturnedDate = new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -3,
                            BookID = -3,
                            CheckedOutDate = new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2020, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ExtensionCount = 0
                        });
                });

            modelBuilder.Entity("LibraryDueDateTracker.Models.Book", b =>
                {
                    b.HasOne("LibraryDueDateTracker.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .HasConstraintName("FK_Book_Author")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryDueDateTracker.Models.Borrow", b =>
                {
                    b.HasOne("LibraryDueDateTracker.Models.Book", "Book")
                        .WithMany("Borrows")
                        .HasForeignKey("BookID")
                        .HasConstraintName("FK_Borrow_Book")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
