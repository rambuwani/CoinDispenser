using Microsoft.EntityFrameworkCore.Migrations;

namespace Coin.Dispenser.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoinCheckBoxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinCheckBoxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CoinCheckBoxes",
                columns: new[] { "Id", "Text", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 5, 5 },
                    { 4, 10, 10 },
                    { 5, 20, 20 },
                    { 6, 50, 50 },
                    { 7, 100, 100 },
                    { 8, 200, 200 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "AQAAAAEAACcQAAAAEH1/SgP/J4AEjLqm3iy81qMix2OoNgWnF2XQfJxgYwFKqgDKVMmqYcahArxg4lIo6Q==", "FNB" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoinCheckBoxes");

            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
