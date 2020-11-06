using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDueDateTracker.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(60)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AuthorID = table.Column<int>(type: "int(10)", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    PublicationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Book_Author",
                        column: x => x.AuthorID,
                        principalTable: "author",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "borrow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookID = table.Column<int>(type: "int(10)", nullable: false),
                    CheckedOutDate = table.Column<DateTime>(type: "date", nullable: false),
                    DueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrow", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Borrow_Book",
                        column: x => x.BookID,
                        principalTable: "book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "author",
                columns: new[] { "ID", "BirthDate", "DeathDate", "Name" },
                values: new object[,]
                {
                    { -1, new DateTime(1975, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Brandon Sanderson" },
                    { -2, new DateTime(1973, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Patrick Rothfuss" },
                    { -3, new DateTime(1955, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Douglas Adams" },
                    { -4, new DateTime(1946, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Philip Pullman" },
                    { -5, new DateTime(1965, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Eoin Colfer" }
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "ID", "AuthorID", "PublicationDate", "Title" },
                values: new object[,]
                {
                    { -1, -1, new DateTime(2006, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistborn" },
                    { -2, -1, new DateTime(2010, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Way of Kings" },
                    { -3, -1, new DateTime(2010, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Warbreaker" },
                    { -4, -2, new DateTime(2007, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name of the Wind" },
                    { -5, -2, new DateTime(2011, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Wise Man's Fear" },
                    { -6, -2, new DateTime(2014, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Slow Regard for Silent Things" },
                    { -7, -3, new DateTime(1978, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hitchhiker's Guide to the Galaxy" },
                    { -8, -3, new DateTime(1980, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Life, the Universe, and Everything" },
                    { -9, -3, new DateTime(1980, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "So Long and Thanks for all the Fish" },
                    { -10, -4, new DateTime(1995, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Golden Compass" },
                    { -11, -4, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Subtle Knife" },
                    { -12, -4, new DateTime(2017, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "La Belle Sauvage" },
                    { -13, -5, new DateTime(1997, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artemis Fowl" },
                    { -14, -5, new DateTime(2004, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Airman" },
                    { -15, -5, new DateTime(2009, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "And Another Thing..." }
                });

            migrationBuilder.InsertData(
                table: "borrow",
                columns: new[] { "ID", "BookID", "CheckedOutDate", "DueDate", "ReturnedDate" },
                values: new object[] { -1, -1, new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "borrow",
                columns: new[] { "ID", "BookID", "CheckedOutDate", "DueDate", "ReturnedDate" },
                values: new object[] { -2, -2, new DateTime(2020, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "borrow",
                columns: new[] { "ID", "BookID", "CheckedOutDate", "DueDate", "ReturnedDate" },
                values: new object[] { -3, -3, new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "FK_Book_Author",
                table: "book",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "FK_Borrow_Book",
                table: "borrow",
                column: "BookID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "borrow");

            migrationBuilder.DropTable(
                name: "book");

            migrationBuilder.DropTable(
                name: "author");
        }
    }
}
