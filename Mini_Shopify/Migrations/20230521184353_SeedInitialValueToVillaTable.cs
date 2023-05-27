using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Shopify.Migrations
{
    public partial class SeedInitialValueToVillaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 43, 53, 341, DateTimeKind.Utc).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 43, 53, 341, DateTimeKind.Utc).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 43, 53, 341, DateTimeKind.Utc).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 43, 53, 341, DateTimeKind.Utc).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 43, 53, 341, DateTimeKind.Utc).AddTicks(7698));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 38, 48, 755, DateTimeKind.Utc).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 38, 48, 755, DateTimeKind.Utc).AddTicks(8053));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 38, 48, 755, DateTimeKind.Utc).AddTicks(8054));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 38, 48, 755, DateTimeKind.Utc).AddTicks(8056));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 38, 48, 755, DateTimeKind.Utc).AddTicks(8057));
        }
    }
}
