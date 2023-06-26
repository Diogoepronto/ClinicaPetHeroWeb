using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaPetHeroWeb.Migrations
{
    public partial class AddAppointmentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Appointments");
        }
    }
}
