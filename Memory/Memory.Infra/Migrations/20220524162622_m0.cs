using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Memory.Infra.Migrations
{
    public partial class m0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbAnnotations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Tags = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAnnotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbAnnotations_tbCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tbCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbCategories",
                columns: new[] { "Id", "CategoryName", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[] { new Guid("4a489c39-9565-455c-8df4-1de0083755b2"), "Solid", new DateTime(2022, 5, 24, 13, 26, 22, 509, DateTimeKind.Local).AddTicks(2854), "Best practice do develop", new DateTime(2022, 5, 24, 13, 26, 22, 510, DateTimeKind.Local).AddTicks(1296) });

            migrationBuilder.CreateIndex(
                name: "IX_tbAnnotations_CategoryId",
                table: "tbAnnotations",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAnnotations");

            migrationBuilder.DropTable(
                name: "tbCategories");
        }
    }
}
