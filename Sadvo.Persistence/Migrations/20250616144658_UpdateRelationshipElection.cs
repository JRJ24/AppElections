using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadvo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationshipElection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartyPolitical_Election_ElectionId",
                table: "PartyPolitical");

            migrationBuilder.RenameColumn(
                name: "ElectionId",
                table: "PartyPolitical",
                newName: "ElectionID");

            migrationBuilder.RenameIndex(
                name: "IX_PartyPolitical_ElectionId",
                table: "PartyPolitical",
                newName: "IX_PartyPolitical_ElectionID");

            migrationBuilder.AddColumn<int>(
                name: "ElectionID",
                table: "PoliticalLeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ElectionID",
                table: "PartyPolitical",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElectionID",
                table: "Candidatos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalLeader_ElectionID",
                table: "PoliticalLeader",
                column: "ElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_ElectionID",
                table: "Candidatos",
                column: "ElectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatosElection",
                table: "Candidatos",
                column: "ElectionID",
                principalTable: "Election",
                principalColumn: "ElectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartyPoliticalsElection",
                table: "PartyPolitical",
                column: "ElectionID",
                principalTable: "Election",
                principalColumn: "ElectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalLeadersElection",
                table: "PoliticalLeader",
                column: "ElectionID",
                principalTable: "Election",
                principalColumn: "ElectionId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatosElection",
                table: "Candidatos");

            migrationBuilder.DropForeignKey(
                name: "FK_PartyPoliticalsElection",
                table: "PartyPolitical");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalLeadersElection",
                table: "PoliticalLeader");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalLeader_ElectionID",
                table: "PoliticalLeader");

            migrationBuilder.DropIndex(
                name: "IX_Candidatos_ElectionID",
                table: "Candidatos");

            migrationBuilder.DropColumn(
                name: "ElectionID",
                table: "PoliticalLeader");

            migrationBuilder.DropColumn(
                name: "ElectionID",
                table: "Candidatos");

            migrationBuilder.RenameColumn(
                name: "ElectionID",
                table: "PartyPolitical",
                newName: "ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_PartyPolitical_ElectionID",
                table: "PartyPolitical",
                newName: "IX_PartyPolitical_ElectionId");

            migrationBuilder.AlterColumn<int>(
                name: "ElectionId",
                table: "PartyPolitical",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PartyPolitical_Election_ElectionId",
                table: "PartyPolitical",
                column: "ElectionId",
                principalTable: "Election",
                principalColumn: "ElectionId");
        }
    }
}
