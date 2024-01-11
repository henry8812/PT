using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations.IdentityApp
{
    public partial class addApplicant8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

         

            migrationBuilder.RenameIndex(
                name: "IX_Applicant_UserId",
                table: "Applicants",
                newName: "IX_Applicants_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantProcess_Applicants_ApplicantId",
                table: "ApplicantProcess",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantProcess_Applicants_ApplicantId",
                table: "ApplicantProcess");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Users_UserId",
                table: "Applicants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.RenameTable(
                name: "Applicants",
                newName: "Applicant");

            migrationBuilder.RenameIndex(
                name: "IX_Applicants_UserId",
                table: "Applicant",
                newName: "IX_Applicant_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicant",
                table: "Applicant",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicant_Users_UserId",
                table: "Applicantw",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantProcess_Applicant_ApplicantId",
                table: "ApplicantProcess",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
