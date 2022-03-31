using Microsoft.EntityFrameworkCore.Migrations;

namespace deBuilding.BookSharingService.IdentityServer.Migrations
{
    public partial class AddFirstNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");
        }
    }
}
