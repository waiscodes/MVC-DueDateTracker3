using System;
using Microsoft.EntityFrameworkCore;

namespace LibraryDueDateTracker.Models
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Borrow> Borrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=127.0.0.1;" +
                    "port=8889;" +
                    "user=root;" +
                    "password=root;" +
                    "database=mvc_library;";

                string version = "5.7.26";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                    new Author()
                    {
                        ID = -1,
                        Name = "Brandon Sanderson",
                        BirthDate = new DateTime(1975, 12, 19),
                    },
                    new Author()
                    {
                        ID = -2,
                        Name = "Patrick Rothfuss",
                        BirthDate = new DateTime(1973, 06, 06),
                    },
                    new Author()
                    {
                        ID = -3,
                        Name = "Douglas Adams",
                        BirthDate = new DateTime(1955, 03, 11),
                        DeathDate = new DateTime(2001, 05, 11)
                    },
                    new Author()
                    {
                        ID = -4,
                        Name = "Philip Pullman",
                        BirthDate = new DateTime(1946, 10, 19)
                    },
                    new Author()
                    {
                        ID = -5,
                        Name = "Eoin Colfer",
                        BirthDate = new DateTime(1965, 05, 14)
                    }
                );
            });

            string kiBook = "FK_" + nameof(Book) +
         "_" + nameof(Author);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");
                entity.HasIndex(e => e.AuthorID)
                      .HasName(kiBook);

                entity.HasOne(thisEntity => thisEntity.Author)
                      .WithMany(parent => parent.Books)
                      .HasForeignKey(thisEntity => thisEntity.AuthorID)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName(kiBook);
                entity.HasData(
                    new Book()
                    {
                        ID = -1,
                        AuthorID = -1,
                        Title = "Mistborn",
                        PublicationDate = new DateTime(2006, 07, 17)
                    },
                    new Book()
                    {
                        ID = -2,
                        AuthorID = -1,
                        Title = "The Way of Kings",
                        PublicationDate = new DateTime(2010, 08, 31)
                    },
                    new Book()
                    {
                        ID = -3,
                        AuthorID = -1,
                        Title = "Warbreaker",
                        PublicationDate = new DateTime(2010, 08, 31)
                    },
                    new Book()
                    {
                        ID = -4,
                        AuthorID = -2,
                        Title = "Name of the Wind",
                        PublicationDate = new DateTime(2007, 03, 27)
                    },
                    new Book()
                    {
                        ID = -5,
                        AuthorID = -2,
                        Title = "The Wise Man's Fear",
                        PublicationDate = new DateTime(2011, 03, 11)
                    },
                    new Book()
                    {
                        ID = -6,
                        AuthorID = -2,
                        Title = "A Slow Regard for Silent Things",
                        PublicationDate = new DateTime(2014, 10, 14)
                    },
                    new Book()
                    {
                        ID = -7,
                        AuthorID = -3,
                        Title = "Hitchhiker's Guide to the Galaxy",
                        PublicationDate = new DateTime(1978, 08, 31)
                    },
                    new Book()
                    {
                        ID = -8,
                        AuthorID = -3,
                        Title = "Life, the Universe, and Everything",
                        PublicationDate = new DateTime(1980, 10, 31)
                    },
                    new Book()
                    {
                        ID = -9,
                        AuthorID = -3,
                        Title = "So Long and Thanks for all the Fish",
                        PublicationDate = new DateTime(1980, 10, 31)
                    },
                    new Book()
                    {
                        ID = -10,
                        AuthorID = -4,
                        Title = "The Golden Compass",
                        PublicationDate = new DateTime(1995, 07, 01)
                    },
                    new Book()
                    {
                        ID = -11,
                        AuthorID = -4,
                        Title = "The Subtle Knife",
                        PublicationDate = new DateTime(1997, 01, 01)
                    },
                    new Book()
                    {
                        ID = -12,
                        AuthorID = -4,
                        Title = "La Belle Sauvage",
                        PublicationDate = new DateTime(2017, 10, 21)
                    },
                    new Book()
                    {
                        ID = -13,
                        AuthorID = -5,
                        Title = "Artemis Fowl",
                        PublicationDate = new DateTime(1997, 01, 21)
                    },
                    new Book()
                    {
                        ID = -14,
                        AuthorID = -5,
                        Title = "Airman",
                        PublicationDate = new DateTime(2004, 06, 26)
                    },
                    new Book()
                    {
                        ID = -15,
                        AuthorID = -5,
                        Title = "And Another Thing...",
                        PublicationDate = new DateTime(2009, 10, 12)
                    }
                );

            });

            string bBook = "FK_" + nameof(Borrow) +
         "_" + nameof(Book);
            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.HasIndex(e => e.BookID)
                      .HasName(bBook);

                entity.HasOne(thisEntity => thisEntity.Book)
                      .WithMany(parent => parent.Borrows)
                      .HasForeignKey(thisEntity => thisEntity.BookID)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName(bBook);

                entity.HasData(
                    new Borrow()
                    {
                        ID = -1,
                        BookID = -1,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        DueDate = new DateTime(2020, 01, 07),
                        ReturnedDate = new DateTime(2020, 01, 06)
                    },
                    new Borrow()
                    {
                        ID = -2,
                        BookID = -2,
                        CheckedOutDate = new DateTime(2020, 08, 24),
                        DueDate = new DateTime(2020, 09, 13),
                        ReturnedDate = new DateTime(2020, 09, 12)
                    },
                    new Borrow()
                    {
                        ID = -3,
                        BookID = -3,
                        CheckedOutDate = new DateTime(2020, 10, 10),
                        DueDate = new DateTime(2020, 10, 24)
                    }
                );
            });
        }
    }
}
