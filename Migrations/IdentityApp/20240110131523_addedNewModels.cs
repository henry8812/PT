using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations.IdentityApp
{
    public partial class addedNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessUser");

            migrationBuilder.AddColumn<string>(
                name: "BasicInfo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LevelId",
                table: "Processes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfQuestions",
                table: "Processes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestTypeId",
                table: "Processes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Processes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicantProcess",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId1 = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestResult = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantProcess", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_ApplicantProcess_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantProcess_Users_ApplicantId1",
                        column: x => x.ApplicantId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    LevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.LevelId);
                });

            migrationBuilder.CreateTable(
                name: "TestType",
                columns: table => new
                {
                    TestTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestType", x => x.TestTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processes_LevelId",
                table: "Processes",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_TestTypeId",
                table: "Processes",
                column: "TestTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Processes_UserId",
                table: "Processes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantProcess_ApplicantId1",
                table: "ApplicantProcess",
                column: "ApplicantId1");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantProcess_ProcessId",
                table: "ApplicantProcess",
                column: "ProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Level_LevelId",
                table: "Processes",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_TestType_TestTypeId",
                table: "Processes",
                column: "TestTypeId",
                principalTable: "TestType",
                principalColumn: "TestTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Processes_Users_UserId",
                table: "Processes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Level_LevelId",
                table: "Processes");

            migrationBuilder.DropForeignKey(
                name: "FK_Processes_TestType_TestTypeId",
                table: "Processes");

            migrationBuilder.DropForeignKey(
                name: "FK_Processes_Users_UserId",
                table: "Processes");

            migrationBuilder.DropTable(
                name: "ApplicantProcess");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "TestType");

            migrationBuilder.DropIndex(
                name: "IX_Processes_LevelId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_TestTypeId",
                table: "Processes");

            migrationBuilder.DropIndex(
                name: "IX_Processes_UserId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "BasicInfo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "NumberOfQuestions",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "TestTypeId",
                table: "Processes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Processes");

            migrationBuilder.CreateTable(
                name: "ProcessUser",
                columns: table => new
                {
                    ApplicantsId = table.Column<int>(type: "int", nullable: false),
                    ProcessesProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessUser", x => new { x.ApplicantsId, x.ProcessesProcessId });
                    table.ForeignKey(
                        name: "FK_ProcessUser_Processes_ProcessesProcessId",
                        column: x => x.ProcessesProcessId,
                        principalTable: "Processes",
                        principalColumn: "ProcessId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessUser_Users_ApplicantsId",
                        column: x => x.ApplicantsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessUser_ProcessesProcessId",
                table: "ProcessUser",
                column: "ProcessesProcessId");
        }
    }
}
