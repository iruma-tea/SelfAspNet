using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfAspNet.Migrations
{
    /// <inheritdoc />
    public partial class Review : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Body", "BookId", "LastUpdated", "Name" },
                values: new object[,]
                {
                    { 1, "がっつり学習したい人には、うってつけの本です。前半は、キッチリ基礎固めを行い、後半は応用的な内容に。図や用例、構文も多く、辞書代わりにも使えます。", 1, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "山田太郎" },
                    { 2, "環境構築から書かれており初心者から使えますが、分量から見てもわかるように、サラッとは終わらず、説明が深いです。特に「エキスパートに訊く」という読み物が面白い。", 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "佐藤花子" },
                    { 3, "コツコツ、独りでじっくり勉強できます。オブジェクト指向プログラミングに紙数が割いてあって、以前、挫折したけど、今回は理解できました。1回目は読み飛ばしたところもあるので、また読み返したいです。", 1, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "鈴木次郎" },
                    { 4, "Androidはすぐにバージョンが上がるので、本を買うのもためらわれるが、この本は、基礎部分がしっかり説明されているので、はじめの一冊にお勧めできます。", 2, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "井上裕子" },
                    { 5, "同様の構成で、Kotlin対応とJava対応があるので、両方手元にあると比較しながら勉強できます。", 2, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "田中健太" },
                    { 6, "テスト、TypeScriptの活用、Next.jsの活用などなど。実践的な内容盛りだくさんで、かなりのボリュームです。サンプルも多く、ダウンロードして実際に動かしながら確認できて、理解が深まります。", 2, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "藤井由美" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");
        }
    }
}
