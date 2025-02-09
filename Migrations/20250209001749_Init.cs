using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace todos2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos2", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Todos2",
                columns: new[] { "Id", "CreatedAt", "IsCompleted", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Learn C#", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Learn ASP.NET Core", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Build a Web API", new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos2");
        }
    }
}
