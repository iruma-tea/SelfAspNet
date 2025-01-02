using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SelfAspNet.Migrations
{
    /// <inheritdoc />
    public partial class CreateArticle : Migration
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
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Isbn", "Price", "Published", "Publisher", "Sample", "Title" },
                values: new object[,]
                {
                    { 1, "978-4-7981-8094-6", 3960, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "翔泳社", true, "独習Java" },
                    { 2, "978-4-7981-7613-0", 3135, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "翔泳社", true, "Androidアプリ開発の教科書" },
                    { 3, "978-4-8156-1948-0", 4400, new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "SBクリエイティブ", true, "これからはじめるReact実践入門" },
                    { 4, "978-4-296-07070-1", 2420, new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "日経BP", false, "作って学べるHTML＋JavaScriptの基本" },
                    { 5, "978-4-297-13685-7", 3520, new DateTime(2023, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "技術評論社", false, "Nuxt 3 フロントエンド開発の教科書" },
                    { 6, "978-4-297-13288-0", 3520, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "技術評論社", true, "JavaScript本格入門" },
                    { 7, "978-4-627-85711-7", 2970, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "森北出版", false, "Pythonでできる! 株価データ分析" },
                    { 8, "978-4-7981-7556-0", 4180, new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "翔泳社", true, "独習C#" },
                    { 9, "978-4-8156-1336-5", 3740, new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "SBクリエイティブ", true, "これからはじめるVue.js 3実践入門" },
                    { 10, "978-4-296-08014-4", 3190, new DateTime(2022, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "日経BP", false, "基礎からしっかり学ぶC#の教科書" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
