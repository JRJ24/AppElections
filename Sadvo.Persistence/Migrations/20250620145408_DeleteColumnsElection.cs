using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadvo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeleteColumnsElection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cantCandidatos",
                table: "Election");

            migrationBuilder.DropColumn(
                name: "cantElectivePositions",
                table: "Election");

            migrationBuilder.DropColumn(
                name: "cantPartyPolitical",
                table: "Election");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cantCandidatos",
                table: "Election",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cantElectivePositions",
                table: "Election",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cantPartyPolitical",
                table: "Election",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
