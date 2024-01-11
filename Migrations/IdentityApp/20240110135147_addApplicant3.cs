using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations.IdentityApp
{
    public partial class addApplicant3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
{


    
    migrationBuilder.DropTable(
        name: "ApplicantProcess");
}


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
