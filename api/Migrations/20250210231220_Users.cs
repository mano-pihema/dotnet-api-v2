using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace todos2.Migrations
{
    /// <inheritdoc />
    public partial class Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                }
            );

            // Insert Users First
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mike" },
                    { 2, "Tim" },
                }
            );

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Todos2",
                type: "int",
                nullable: false,
                defaultValue: 1
            );

            migrationBuilder.UpdateData(
                table: "Todos2",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1
            );

            migrationBuilder.UpdateData(
                table: "Todos2",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 2
            );

            migrationBuilder.UpdateData(
                table: "Todos2",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 1
            );

            migrationBuilder.CreateIndex(
                name: "IX_Todos2_UserId",
                table: "Todos2",
                column: "UserId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Todos2_Users_UserId",
                table: "Todos2",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Todos2_Users_UserId", table: "Todos2");

            migrationBuilder.DropTable(name: "Users");

            migrationBuilder.DropIndex(name: "IX_Todos2_UserId", table: "Todos2");

            migrationBuilder.DropColumn(name: "UserId", table: "Todos2");
        }
    }
}
