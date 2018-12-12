using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationContext.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HorasReloj",
                table: "ActasEUDetalles",
                newName: "HorasRelojRealizadas");

            migrationBuilder.RenameColumn(
                name: "HorasExtension",
                table: "ActasEUDetalles",
                newName: "HorasExtensionRealizadas");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoriaId",
                table: "ActasEUDetalles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "ActasEUDetalles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LugarProfesorTutor",
                table: "ActasEUDetalles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActasEUDetalles_CategoriaId",
                table: "ActasEUDetalles",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActasEUDetalles_Categorias_CategoriaId",
                table: "ActasEUDetalles",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActasEUDetalles_Categorias_CategoriaId",
                table: "ActasEUDetalles");

            migrationBuilder.DropIndex(
                name: "IX_ActasEUDetalles_CategoriaId",
                table: "ActasEUDetalles");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "ActasEUDetalles");

            migrationBuilder.DropColumn(
                name: "LugarProfesorTutor",
                table: "ActasEUDetalles");

            migrationBuilder.RenameColumn(
                name: "HorasRelojRealizadas",
                table: "ActasEUDetalles",
                newName: "HorasReloj");

            migrationBuilder.RenameColumn(
                name: "HorasExtensionRealizadas",
                table: "ActasEUDetalles",
                newName: "HorasExtension");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoriaId",
                table: "ActasEUDetalles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
