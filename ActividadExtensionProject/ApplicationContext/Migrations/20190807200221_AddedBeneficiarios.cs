using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationContext.Migrations
{
    public partial class AddedBeneficiarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeneficiariosHombres",
                table: "ActasEUDetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BeneficiariosMujeres",
                table: "ActasEUDetalles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeneficiariosHombres",
                table: "ActasEUDetalles");

            migrationBuilder.DropColumn(
                name: "BeneficiariosMujeres",
                table: "ActasEUDetalles");
        }
    }
}
