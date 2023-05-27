using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Shopify.Migrations
{
    public partial class InitialState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable("Villas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 19, 25, 75, DateTimeKind.Utc).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 19, 25, 75, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 19, 25, 75, DateTimeKind.Utc).AddTicks(3379));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 19, 25, 75, DateTimeKind.Utc).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 5, 21, 18, 19, 25, 75, DateTimeKind.Utc).AddTicks(3382));
        }
    }
}
