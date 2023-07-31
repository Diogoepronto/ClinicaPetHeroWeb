using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaPetHeroWeb.Migrations
{
    public partial class AddImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "PetOwners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnimalImageUrl",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "PetOwners");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AnimalImageUrl",
                table: "Animals");
        }
    }
}
