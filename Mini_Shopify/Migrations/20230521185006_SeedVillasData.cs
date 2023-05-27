using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Shopify.Migrations
{
    public partial class SeedVillasData : Migration
    {
       protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(table: "Villas",
        columns: new[]
        {
            "Id","Name", "Details", "Rate", "sqft", "Occupancy", "ImageUrl", "Amenity", "CreatedDate", "UpdatedDate"
        },
        values: new object[,]
        {
            { 1, "Villa 1", "Details 1", 100.0, 2000,  1, "Image1.jpg", "Amenity 1", DateTime.UtcNow, DateTime.UtcNow },
            { 2, "Villa 2", "Details 2", 150.0, 2500,  2, "Image2.jpg", "Amenity 2", DateTime.UtcNow, DateTime.UtcNow },
            // Add more initial values here as needed
        });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
