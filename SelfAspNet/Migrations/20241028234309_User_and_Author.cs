using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfAspNet.Migrations
{
    /// <inheritdoc />
    public partial class User_and_Author : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Birth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NeedNews = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PenName = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    BooksId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UserId",
                table: "Authors",
                column: "UserId",
                unique: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birth", "Email", "Name", "NeedNews" },
                values: new object[,]
                {
                        { 1, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "yyamada@example.com", "山田祥寛", false },
                        { 2, new DateTime(1970, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "nyamauchi@example.com", "山内直", false },
                        { 3, new DateTime(1990, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "hsuzuki@example.com", "鈴木花子", false },
                        { 4, new DateTime(1992, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "tsato@example.com", "佐藤太郎", false },
                        { 5, new DateTime(1985, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "kkatafuchi@example.com", "片渕彼富", false },
                        { 6, new DateTime(1974, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ssaito@example.com", "齊藤新三", false },
                        { 7, new DateTime(2000, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shanako@example.com", "鈴木花子", false },
                        { 8, new DateTime(1978, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ktakae@example.com", "高江賢", false }
                }
            );

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "PenName", "UserId" },
                values: new object[,]
                {
                    { 1, "WINGS", 1 },
                    { 2, "Sarva", 6 },
                    { 3, "たまデジ。", 2 },
                    { 4, "Canon", 5 },
                    { 5, "Papier", 8 },
                    { 6, "はな", 3 }
                }
            );

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsId", "BooksId" },
                values: new object[,]
                {
                                { 1, 1 },
                                { 6, 1 },
                                { 2, 2 },
                                { 1, 3 },
                                { 3, 4 },
                                { 2, 5 },
                                { 1, 6 },
                                { 4, 7 },
                                { 1, 8 },
                                { 1, 9 },
                                { 5, 10 }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
