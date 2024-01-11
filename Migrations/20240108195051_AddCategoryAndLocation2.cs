using Microsoft.EntityFrameworkCore.Migrations;

namespace PTSeleccion.Migrations
{
    public partial class AddCategoryAndLocation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear la tabla Category
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            // Crear la tabla Location
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            // Agregar las columnas CategoryId y LocationId a la tabla JobOffers
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "JobOffers",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "JobOffers",
                nullable: false);

            // Crear las relaciones entre JobOffers y Category/Location
            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CategoryId",
                table: "JobOffers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_LocationId",
                table: "JobOffers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Category_CategoryId",
                table: "JobOffers",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Location_LocationId",
                table: "JobOffers",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar las relaciones y columnas
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Category_CategoryId",
                table: "JobOffers");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Location_LocationId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CategoryId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_LocationId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "JobOffers");

            // Eliminar las tablas creadas
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
