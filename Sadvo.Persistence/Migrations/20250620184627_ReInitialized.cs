using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadvo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReInitialized : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logoTypePartyPolitical",
                table: "PartyPolitical");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Candidatos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "logoTypePartyPolitical",
                table: "PartyPolitical",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Candidatos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
