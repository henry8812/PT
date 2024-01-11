using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations.IdentityApp
{
    public partial class addApplicant2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_Users_ApplicantId",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "BasicInfo",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "Applicant");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "Applicant",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Applicant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Applicant_UserId",
                table: "Applicant",
                column: "UserId",
                unique: true);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_Users_UserId",
                table: "Applicant");

            migrationBuilder.DropIndex(
                name: "IX_Applicant_UserId",
                table: "Applicant");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Applicant");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantId",
                table: "Applicant",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "BasicInfo",
                table: "Applicant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "Applicant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicant_Users_ApplicantId",
                table: "Applicant",
                column: "ApplicantId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
