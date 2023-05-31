using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Shopify.Migrations
{
    public partial class AddForeignKeyToVillaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaID",
                table: "VillasNumber",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 20, 30, 48, 975, DateTimeKind.Utc).AddTicks(8311));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 20, 30, 48, 975, DateTimeKind.Utc).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 20, 30, 48, 975, DateTimeKind.Utc).AddTicks(8313));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 20, 30, 48, 975, DateTimeKind.Utc).AddTicks(8314));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 31, 20, 30, 48, 975, DateTimeKind.Utc).AddTicks(8315));

            migrationBuilder.CreateIndex(
                name: "IX_VillasNumber_VillaID",
                table: "VillasNumber",
                column: "VillaID");

            migrationBuilder.AddForeignKey(
                name: "FK_VillasNumber_Villas_VillaID",
                table: "VillasNumber",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillasNumber_Villas_VillaID",
                table: "VillasNumber");

            migrationBuilder.DropIndex(
                name: "IX_VillasNumber_VillaID",
                table: "VillasNumber");

            migrationBuilder.DropColumn(
                name: "VillaID",
                table: "VillasNumber");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 21, 7, 18, 695, DateTimeKind.Utc).AddTicks(8933));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 21, 7, 18, 695, DateTimeKind.Utc).AddTicks(8936));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 21, 7, 18, 695, DateTimeKind.Utc).AddTicks(8937));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 21, 7, 18, 695, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 21, 7, 18, 695, DateTimeKind.Utc).AddTicks(8939));
        }
    }
}
