using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mini_Shopify.Migrations
{
    public partial class SeedDataToVillaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData( table: "Villas",
        columns: new[]
        {
            "Name", "Details", "Rate", "sqft", "Occupancy", "ImageUrl", "Amenity", "CreatedDate", "UpdatedDate"
        },
        values: new object[,]
        {
            { "Villa 1", "Details 1", 100.0, 2000, "Occupancy 1", "Image1.jpg", "Amenity 1", DateTime.UtcNow, DateTime.UtcNow },
            { "Villa 2", "Details 2", 150.0, 2500, "Occupancy 2", "Image2.jpg", "Amenity 2", DateTime.UtcNow, DateTime.UtcNow },
            // Add more initial values here as needed
        });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Villas");
        }
    }
}
