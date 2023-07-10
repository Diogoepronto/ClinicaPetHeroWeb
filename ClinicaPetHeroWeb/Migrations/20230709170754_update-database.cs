using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicaPetHeroWeb.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Owners_OwnerId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Owners_OwnerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_User_UserId",
                table: "Owners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Owners",
                table: "Owners");

            migrationBuilder.RenameTable(
                name: "Owners",
                newName: "PetOwners");

            migrationBuilder.RenameIndex(
                name: "IX_Owners_UserId",
                table: "PetOwners",
                newName: "IX_PetOwners_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetOwners",
                table: "PetOwners",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_PetOwners_OwnerId",
                table: "Animals",
                column: "OwnerId",
                principalTable: "PetOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_PetOwners_OwnerId",
                table: "Appointments",
                column: "OwnerId",
                principalTable: "PetOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetOwners_User_UserId",
                table: "PetOwners",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_PetOwners_OwnerId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_PetOwners_OwnerId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_PetOwners_User_UserId",
                table: "PetOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetOwners",
                table: "PetOwners");

            migrationBuilder.RenameTable(
                name: "PetOwners",
                newName: "Owners");

            migrationBuilder.RenameIndex(
                name: "IX_PetOwners_UserId",
                table: "Owners",
                newName: "IX_Owners_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Owners",
                table: "Owners",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Owners_OwnerId",
                table: "Animals",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Owners_OwnerId",
                table: "Appointments",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_User_UserId",
                table: "Owners",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
