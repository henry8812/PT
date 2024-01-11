using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations.IdentityApp
{
    public partial class addApplicant6 : Migration
    {
protected override void Up(MigrationBuilder migrationBuilder)
{
    migrationBuilder.CreateTable(
        name: "ApplicationProcess",
        columns: table => new
        {
            ApplicantProcessId = table.Column<int>(type: "int", nullable: false),
            ApplicantId = table.Column<int>(type: "int", nullable: false),
            ProcessId = table.Column<int>(type: "int", nullable: false),
            StatusId = table.Column<int>(type: "int", nullable: false),
            TestResult = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
        },
        constraints: table =>
        {
            table.PrimaryKey("PK_ApplicationProcesses", x => x.ApplicantProcessId);
            table.ForeignKey(
                name: "FK_ApplicationProcesses_Applicants_ApplicantId",
                column: x => x.ApplicantId,
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                name: "FK_ApplicationProcesses_Processes_ProcessId",
                column: x => x.ProcessId,
                principalTable: "Processes",
                principalColumn: "ProcessId",
                onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                name: "FK_ApplicationProcesses_Status_StatusId",
                column: x => x.StatusId,
                principalTable: "Status",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateIndex(
        name: "IX_ApplicationProcesses_ApplicantId",
        table: "ApplicationProcess",
        column: "ApplicantId");

    migrationBuilder.CreateIndex(
        name: "IX_ApplicationProcesses_ProcessId",
        table: "ApplicationProcess",
        column: "ProcessId");

    migrationBuilder.CreateIndex(
        name: "IX_ApplicationProcesses_StatusId",
        table: "ApplicationProcess",
        column: "StatusId");
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    migrationBuilder.DropTable(
        name: "ApplicationProcesses");
}

    }
}
