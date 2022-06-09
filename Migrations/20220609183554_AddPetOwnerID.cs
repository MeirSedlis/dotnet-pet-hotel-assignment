using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_bakery.Migrations
{
    public partial class AddPetOwnerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "petOwnerId",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_petOwnerId",
                table: "Pets",
                column: "petOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerId",
                table: "Pets",
                column: "petOwnerId",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_petOwnerId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "petOwnerId",
                table: "Pets");
        }
    }
}
