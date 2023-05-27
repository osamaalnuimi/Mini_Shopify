using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Shopify.Migrations
{
    public partial class UpdateVillaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "Occupancy",
            table: "Villas",
            nullable: false,
            oldClrType: typeof(string),
            oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
            name: "Occupancy",
            table: "Villas",
            nullable: true,
            oldClrType: typeof(int));
        }
    }
}
