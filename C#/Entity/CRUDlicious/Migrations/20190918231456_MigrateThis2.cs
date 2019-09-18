using Microsoft.EntityFrameworkCore.Migrations;

namespace Crudlicious.Migrations
{
    public partial class MigrateThis2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Dish",
                newName: "DishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DishId",
                table: "Dish",
                newName: "ID");
        }
    }
}
