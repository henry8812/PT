using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations.IdentityApp
{
    public partial class addApplicant4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantProcess",
                columns: table => new
                {
                    ApplicantProcessId = table.Column<int>(nullable: false),
                    ApplicantId = table.Column<int>(nullable: false),
                    ProcessId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TestResult = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantProcess", x => x.ApplicantProcessId);
                    table.ForeignKey(
                        name: "FK_ApplicantProcess_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantProcess_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantProcess_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantProcess_ApplicantId",
                table: "ApplicantProcess",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantProcess_ProcessId",
                table: "ApplicantProcess",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantProcess_StatusId",
                table: "ApplicantProcess",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantProcess");
        }

    }
}
