using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibrary.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InittialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Booklibrary");

            migrationBuilder.CreateTable(
                name: "authors",
                schema: "Booklibrary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "Booklibrary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                schema: "Booklibrary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_returned = table.Column<bool>(type: "boolean", nullable: false),
                    category_id = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    author_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors",
                        column: x => x.author_id,
                        principalSchema: "Booklibrary",
                        principalTable: "authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Categories",
                        column: x => x.category_id,
                        principalSchema: "Booklibrary",
                        principalTable: "categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "checkouts",
                schema: "Booklibrary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    start_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 2, 11, 19, 12, 40, 396, DateTimeKind.Utc).AddTicks(7508)),
                    end_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    borrower = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_checkouts_books_book_id",
                        column: x => x.book_id,
                        principalSchema: "Booklibrary",
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Booklibrary",
                table: "authors",
                columns: new[] { "Id", "first_name", "last_name" },
                values: new object[,]
                {
                    { 1, "Yaşar", "Kemal" },
                    { 2, "Orhan", "Pamuk" },
                    { 3, "Oğuz", "Atay" }
                });

            migrationBuilder.InsertData(
                schema: "Booklibrary",
                table: "categories",
                columns: new[] { "Id", "name" },
                values: new object[,]
                {
                    { 1, "Fiction" },
                    { 2, "Novel" },
                    { 3, "Science" }
                });

            migrationBuilder.InsertData(
                schema: "Booklibrary",
                table: "books",
                columns: new[] { "Id", "author_id", "category_id", "image_url", "is_returned", "name" },
                values: new object[,]
                {
                    { 1, 1, 1, "1.jfif", false, "İnce Memed 1" },
                    { 2, 1, 1, "2.jfif", true, "Yılanı Öldürseler" },
                    { 3, 2, 2, "3.jfif", true, "Mausmiyet Müzesi" },
                    { 4, 2, 2, "4.jpg", true, "Kırmızı Saçlı Kadın" },
                    { 5, 3, 2, "5.jpg", true, "Tutunamayanlar" },
                    { 6, 3, 2, "6.jpg", true, "Tehlikeli Oyunlar" },
                    { 7, 3, 2, "7.jpg", true, "EylemBilim" }
                });

            migrationBuilder.InsertData(
                schema: "Booklibrary",
                table: "checkouts",
                columns: new[] { "Id", "book_id", "borrower", "end_time", "start_time" },
                values: new object[,]
                {
                    { 1, 1, "Kayıhan Nedim", new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1630), new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1628) },
                    { 2, 1, "Emine Münevver", new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1639), new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1639) },
                    { 3, 2, "Fatma Özlem", new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1642), new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1642) },
                    { 4, 1, "Emre Ayberk", new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1644), new DateTime(2024, 2, 11, 19, 12, 40, 397, DateTimeKind.Utc).AddTicks(1644) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_author_id",
                schema: "Booklibrary",
                table: "books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_books_category_id",
                schema: "Booklibrary",
                table: "books",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_checkouts_book_id",
                schema: "Booklibrary",
                table: "checkouts",
                column: "book_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checkouts",
                schema: "Booklibrary");

            migrationBuilder.DropTable(
                name: "books",
                schema: "Booklibrary");

            migrationBuilder.DropTable(
                name: "authors",
                schema: "Booklibrary");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "Booklibrary");
        }
    }
}
