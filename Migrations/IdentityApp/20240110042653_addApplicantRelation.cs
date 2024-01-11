using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations.IdentityApp
{
    public partial class addApplicantRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProcessId",
                table: "Users",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Processes_ProcessId",
                table: "Users",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "ProcessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Processes_ProcessId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProcessId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "Users");
        }
    }
}
