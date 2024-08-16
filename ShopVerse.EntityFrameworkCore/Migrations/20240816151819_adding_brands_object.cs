using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopVerse.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class adding_brands_object : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Tablename",
                schema: "ShopVerse",
                table: "Tablename");

            migrationBuilder.RenameTable(
                name: "Tablename",
                schema: "ShopVerse",
                newName: "Demos",
                newSchema: "ShopVerse");

            migrationBuilder.RenameIndex(
                name: "IX_Tablename_Name",
                schema: "ShopVerse",
                table: "Demos",
                newName: "IX_Demos_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Demos",
                schema: "ShopVerse",
                table: "Demos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "ShopVerse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEstablished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                schema: "ShopVerse",
                table: "Brands",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands",
                schema: "ShopVerse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Demos",
                schema: "ShopVerse",
                table: "Demos");

            migrationBuilder.RenameTable(
                name: "Demos",
                schema: "ShopVerse",
                newName: "Tablename",
                newSchema: "ShopVerse");

            migrationBuilder.RenameIndex(
                name: "IX_Demos_Name",
                schema: "ShopVerse",
                table: "Tablename",
                newName: "IX_Tablename_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tablename",
                schema: "ShopVerse",
                table: "Tablename",
                column: "Id");
        }
    }
}
