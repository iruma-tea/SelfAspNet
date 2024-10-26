using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfAspNet.Migrations
{
    /// <inheritdoc />
    public partial class Article : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Category", "CreatedAt", "LastUpdatedAt", "Title", "Url" },
                                values: new object[,]
                {
                    { 1, "JavaScript", new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ますます便利になるTypeScript！", "https://codezine.jp/article/corner/992" },
                    { 2, "JavaScript", new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Remixを通じてWebを学ぶ", "https://codezine.jp/article/corner/942" },
                    { 3, "JavaScript", new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Web Componentsを基礎から学ぶ", "https://codezine.jp/article/corner/927" },
                    { 4, "Rails", new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Railsの新機能を知ろう！", "https://codezine.jp/article/corner/991" },
                    { 5, "Rails", new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Railsによるクライアントサイド開発入門", "https://codezine.jp/article/corner/919" },
                    { 6, "Rust", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "現場で役立つRust入門", "https://atmarkit.itmedia.co.jp/ait/series/36943/" },
                    { 7, "Rust", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "基本からしっかり学ぶRust入門", "https://atmarkit.itmedia.co.jp/ait/series/24844/" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}
