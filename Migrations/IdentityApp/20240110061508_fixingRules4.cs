using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations.IdentityApp
{
    public partial class fixingRules4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Questions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
