using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Shopify.Migrations
{
    public partial class seedDummayDataToVillaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 14, 41, 214, DateTimeKind.Utc).AddTicks(5991));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 14, 41, 214, DateTimeKind.Utc).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 14, 41, 214, DateTimeKind.Utc).AddTicks(5995));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 14, 41, 214, DateTimeKind.Utc).AddTicks(5996));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 14, 41, 214, DateTimeKind.Utc).AddTicks(5997));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 17, 30, 52, 260, DateTimeKind.Utc).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 17, 30, 52, 260, DateTimeKind.Utc).AddTicks(7907));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 17, 30, 52, 260, DateTimeKind.Utc).AddTicks(7908));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 17, 30, 52, 260, DateTimeKind.Utc).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 17, 30, 52, 260, DateTimeKind.Utc).AddTicks(7911));
        }
    }
}
