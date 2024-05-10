using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SollyLearn.API.Migrations
{
    /// <inheritdoc />
    public partial class AddingSollyLearnDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechStacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechStackImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechStacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TechStackId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_TechStacks_TechStackId",
                        column: x => x.TechStackId,
                        principalTable: "TechStacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TechStacks",
                columns: new[] { "Id", "Description", "Name", "TechStackImageURL" },
                values: new object[,]
                {
                    { new Guid("41b65a0e-1097-4759-a51c-e031d6ceb8b6"), "First Learning Video", "Utkarsh", "" },
                    { new Guid("505037a5-be9d-4b30-b1ab-6dcff18ae655"), "First Frontend Video", "FrontEnd", "" },
                    { new Guid("7fc2efac-fe9f-4996-af23-b4f127bb7752"), "First C# Video", "C#", "" },
                    { new Guid("a4eb5696-0e8e-417b-bf47-cdcca646e9bb"), "First LabView Video", "LabView", "" },
                    { new Guid("e93cb985-4533-4df8-bf6b-0e4e4c18d320"), "First Python Video", "Python", "" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "DateTime", "Description", "FilePath", "TechStackId", "Title" },
                values: new object[,]
                {
                    { new Guid("37be0b6d-e5c8-4cc0-8440-492dad53197e"), new DateTime(2024, 3, 26, 21, 50, 3, 537, DateTimeKind.Local).AddTicks(2030), "My Second Video", "FilePath of the Second video", new Guid("505037a5-be9d-4b30-b1ab-6dcff18ae655"), "SecondTitle" },
                    { new Guid("d8a86a48-51f9-4db4-bca5-99391c05d1de"), new DateTime(2024, 3, 26, 21, 50, 3, 537, DateTimeKind.Local).AddTicks(2001), "My First Video", "FilePath of the First video", new Guid("7fc2efac-fe9f-4996-af23-b4f127bb7752"), "Title" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_TechStackId",
                table: "Videos",
                column: "TechStackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "TechStacks");
        }
    }
}
