using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadvo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserCitizensRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Citizens",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_userName",
                table: "Citizens",
                column: "userName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_USERNAME_CITIZENS",
                table: "Citizens",
                column: "userName",
                principalTable: "Users",
                principalColumn: "userName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_USERNAME_CITIZENS",
                table: "Citizens");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_userName",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Citizens");
        }
    }
}
