using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updaterelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QualityCharacteristicsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DecimalPlaces = table.Column<double>(type: "float", nullable: false),
                    InferiorLimit = table.Column<double>(type: "float", nullable: false),
                    SuperiorLimit = table.Column<double>(type: "float", nullable: false),
                    MaterialModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityCharacteristicsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityCharacteristicsModel_Materials_MaterialModelId",
                        column: x => x.MaterialModelId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualityVisionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumQuantity = table.Column<int>(type: "int", nullable: false),
                    TypeOfCalculation = table.Column<int>(type: "int", nullable: false),
                    MaterialModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityVisionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityVisionModel_Materials_MaterialModelId",
                        column: x => x.MaterialModelId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QualityCharacteristicsModel_MaterialModelId",
                table: "QualityCharacteristicsModel",
                column: "MaterialModelId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityVisionModel_MaterialModelId",
                table: "QualityVisionModel",
                column: "MaterialModelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityCharacteristicsModel");

            migrationBuilder.DropTable(
                name: "QualityVisionModel");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
