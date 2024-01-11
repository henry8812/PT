using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations
{
    public partial class modifyUserModel31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
