using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace todos2.Migrations
{
    /// <inheritdoc />
    public partial class TodoDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TodoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoDetails_Todos2_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TodoDetails",
                columns: new[] { "Id", "Description", "TodoId" },
                values: new object[,]
                {
                    { 1, "Need to learn to build a .Net web API", 3 },
                    { 2, "Need to learn more about C sharp", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoDetails_TodoId",
                table: "TodoDetails",
                column: "TodoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoDetails");
        }
    }
}
