using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadvo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlterTablePoliticalLeader_ColumnAddPoliticalLeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "PoliticalLeader",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "PoliticalLeader");
        }
    }
}
