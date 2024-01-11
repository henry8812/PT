using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations.IdentityApp
{
    public partial class addedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantProcess_Users_ApplicantId1",
                table: "ApplicantProcess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantProcess",
                table: "ApplicantProcess");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ApplicantProcess");

            migrationBuilder.RenameColumn(
                name: "ApplicantId1",
                table: "ApplicantProcess",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantProcess_ApplicantId1",
                table: "ApplicantProcess",
                newName: "IX_ApplicantProcess_StatusId");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "ApplicantProcess",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantProcessId",
                table: "ApplicantProcess",
                type: "int",
                nullable: false,
                defaultValue: 0);
               

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantProcess",
                table: "ApplicantProcess",
                column: "ApplicantProcessId");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantProcess_ApplicantId",
                table: "ApplicantProcess",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantProcess_Status_StatusId",
                table: "ApplicantProcess",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);

    
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantProcess_Status_StatusId",
                table: "ApplicantProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantProcess_Users_ApplicantId",
                table: "ApplicantProcess");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantProcess",
                table: "ApplicantProcess");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantProcess_ApplicantId",
                table: "ApplicantProcess");

            migrationBuilder.DropColumn(
                name: "ApplicantProcessId",
                table: "ApplicantProcess");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "ApplicantProcess",
                newName: "ApplicantId1");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicantProcess_StatusId",
                table: "ApplicantProcess",
                newName: "IX_ApplicantProcess_ApplicantId1");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "ApplicantProcess",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ApplicantProcess",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantProcess",
                table: "ApplicantProcess",
                column: "ApplicantId");

        }
    }
}
