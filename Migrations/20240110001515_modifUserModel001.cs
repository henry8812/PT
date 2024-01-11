using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PTSeleccion.Migrations
{
    public partial class modifUserModel001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Primero, eliminamos la restricción que depende de la columna 'Id'

            migrationBuilder.DropPrimaryKey("PK_Users", "Users"); // Si 'Id' es la llave primaria de 'Users'

            // Luego, eliminamos la columna 'Id'
            migrationBuilder.DropColumn("Id", "Users");

            // Finalmente, agregamos la columna 'Id' con la propiedad 'Identity'
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            // Reagregamos la llave primaria si es necesario
            migrationBuilder.AddPrimaryKey("PK_Users", "Users", "Id");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false);
        }

    }
}
