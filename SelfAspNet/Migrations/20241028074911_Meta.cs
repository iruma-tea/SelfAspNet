using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SelfAspNet.Migrations
{
    /// <inheritdoc />
    public partial class Meta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Controller = table.Column<string>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Metas",
                columns: new[] { "Id", "Action", "Content", "Controller", "Name" },
                values: new object[,]
                {
                    { 1, "Privacy", "メタ情報", "Home", "keywords" },
                    { 2, "Privacy", "ページごとに異なる<meta>要素を生成", "Home", "description" },
                    { 3, "Index", "メタ情報取得の別解", "Tag", "description" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metas");
        }
    }
}
