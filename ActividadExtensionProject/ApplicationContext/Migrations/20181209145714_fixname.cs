using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationContext.Migrations
{
    public partial class fixname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategoriaS_Categorias_CategoriaId",
                table: "SubCategoriaS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategoriaS",
                table: "SubCategoriaS");

            migrationBuilder.RenameTable(
                name: "SubCategoriaS",
                newName: "SubCategorias");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategoriaS_CategoriaId",
                table: "SubCategorias",
                newName: "IX_SubCategorias_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategorias",
                table: "SubCategorias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategorias_Categorias_CategoriaId",
                table: "SubCategorias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategorias",
                table: "SubCategorias");

            migrationBuilder.RenameTable(
                name: "SubCategorias",
                newName: "SubCategoriaS");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategorias_CategoriaId",
                table: "SubCategoriaS",
                newName: "IX_SubCategoriaS_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategoriaS",
                table: "SubCategoriaS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategoriaS_Categorias_CategoriaId",
                table: "SubCategoriaS",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
