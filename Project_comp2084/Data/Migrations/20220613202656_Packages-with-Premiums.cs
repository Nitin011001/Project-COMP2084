using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_comp2084.Data.Migrations
{
    public partial class PackageswithPremiums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PackageName",
                table: "Packages",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Categories",
                table: "Packages",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PremiumId",
                table: "Packages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Premium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Premium", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PremiumId",
                table: "Packages",
                column: "PremiumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Premium_PremiumId",
                table: "Packages",
                column: "PremiumId",
                principalTable: "Premium",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Premium_PremiumId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "Premium");

            migrationBuilder.DropIndex(
                name: "IX_Packages_PremiumId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "PremiumId",
                table: "Packages");

            migrationBuilder.AlterColumn<string>(
                name: "PackageName",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Categories",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
