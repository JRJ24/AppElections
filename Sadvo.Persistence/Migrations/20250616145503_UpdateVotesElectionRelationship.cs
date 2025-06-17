using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadvo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVotesElectionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElectionID",
                table: "Votes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ElectionID",
                table: "Votes",
                column: "ElectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_VotesElection",
                table: "Votes",
                column: "ElectionID",
                principalTable: "Election",
                principalColumn: "ElectionId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VotesElection",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_ElectionID",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "ElectionID",
                table: "Votes");
        }
    }
}
