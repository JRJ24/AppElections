using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadvo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AliancePolitical",
                columns: table => new
                {
                    ID_Aliance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_PartyPolitical_Send = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name_PartyPolitical_Recived = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Aliance_Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AliancePolitical", x => x.ID_Aliance);
                });

            migrationBuilder.CreateTable(
                name: "Election",
                columns: table => new
                {
                    ElectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameElections = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    dateElections = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cantPartyPolitical = table.Column<int>(type: "int", nullable: false),
                    cantElectivePositions = table.Column<int>(type: "int", nullable: false),
                    cantCandidatos = table.Column<int>(type: "int", nullable: false),
                    yearElections = table.Column<int>(type: "int", nullable: false),
                    isActiveElection = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Election", x => x.ElectionId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRol = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.UniqueConstraint("UQ_NAMEROL", x => x.NameRol);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    userName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("UQ_KEY_EMAIL", x => x.email);
                    table.UniqueConstraint("UQ_KEY_USERNAME", x => x.userName);
                });

            migrationBuilder.CreateTable(
                name: "ElectivePositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectionID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectivePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ELECTIONSPOSITIONSELECTIONS",
                        column: x => x.ElectionID,
                        principalTable: "Election",
                        principalColumn: "ElectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartyPolitical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    siglasPartyPolitical = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    logoTypePartyPolitical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectionID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyPolitical", x => x.Id);
                    table.UniqueConstraint("UQ_SiglasPartyPolitical", x => x.siglasPartyPolitical);
                    table.ForeignKey(
                        name: "FK_PartyPoliticalsElection",
                        column: x => x.ElectionID,
                        principalTable: "Election",
                        principalColumn: "ElectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    numberIdentity = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    isVoted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USERNAME_CITIZENS",
                        column: x => x.userName,
                        principalTable: "Users",
                        principalColumn: "userName");
                });

            migrationBuilder.CreateTable(
                name: "RolUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    rolID = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolID_Roles",
                        column: x => x.rolID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserID_Users",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isAssocciate = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ElectionID = table.Column<int>(type: "int", nullable: false),
                    partyPoliticalId = table.Column<int>(type: "int", nullable: true),
                    electivePositionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
                    table.UniqueConstraint("AK_Users_Name_LastName", x => new { x.Name, x.LastName });
                    table.ForeignKey(
                        name: "FK_CandidatosElection",
                        column: x => x.ElectionID,
                        principalTable: "Election",
                        principalColumn: "ElectionId");
                    table.ForeignKey(
                        name: "FK_Candidatos_ElectivePositions_electivePositionId",
                        column: x => x.electivePositionId,
                        principalTable: "ElectivePositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Candidatos_PartyPolitical_partyPoliticalId",
                        column: x => x.partyPoliticalId,
                        principalTable: "PartyPolitical",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartyPoliticalAliance",
                columns: table => new
                {
                    AliancePoliticalId = table.Column<int>(type: "int", nullable: false),
                    PartyPoliticalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyPoliticalAliance", x => new { x.AliancePoliticalId, x.PartyPoliticalId });
                    table.ForeignKey(
                        name: "FK_PartyPoliticalAliance_AliancePolitical_AliancePoliticalId",
                        column: x => x.AliancePoliticalId,
                        principalTable: "AliancePolitical",
                        principalColumn: "ID_Aliance",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartyPoliticalAliance_PartyPolitical_PartyPoliticalId",
                        column: x => x.PartyPoliticalId,
                        principalTable: "PartyPolitical",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoliticalLeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    siglasPartyPolitical = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ElectionID = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalLeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalLeader_PartyPolitical_siglasPartyPolitical",
                        column: x => x.siglasPartyPolitical,
                        principalTable: "PartyPolitical",
                        principalColumn: "siglasPartyPolitical",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoliticalLeadersElection",
                        column: x => x.ElectionID,
                        principalTable: "Election",
                        principalColumn: "ElectionId");
                    table.ForeignKey(
                        name: "FK_USERNAME_POLITICAL_LEADERS",
                        column: x => x.userName,
                        principalTable: "Users",
                        principalColumn: "userName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    citizensID = table.Column<int>(type: "int", nullable: false),
                    siglasPartyPolitical = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    candidatosID = table.Column<int>(type: "int", nullable: false),
                    ElectionID = table.Column<int>(type: "int", nullable: false),
                    isActiveVote = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    partyPoliticalsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CITIZENDSID",
                        column: x => x.citizensID,
                        principalTable: "Citizens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatosID",
                        column: x => x.candidatosID,
                        principalTable: "Candidatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VotesElection",
                        column: x => x.ElectionID,
                        principalTable: "Election",
                        principalColumn: "ElectionId");
                    table.ForeignKey(
                        name: "FK_Votes_PartyPolitical_partyPoliticalsId",
                        column: x => x.partyPoliticalsId,
                        principalTable: "PartyPolitical",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_ElectionID",
                table: "Candidatos",
                column: "ElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_electivePositionId",
                table: "Candidatos",
                column: "electivePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_partyPoliticalId",
                table: "Candidatos",
                column: "partyPoliticalId");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_numberIdentity",
                table: "Citizens",
                column: "numberIdentity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_userName",
                table: "Citizens",
                column: "userName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Election_dateElections",
                table: "Election",
                column: "dateElections",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Election_nameElections",
                table: "Election",
                column: "nameElections",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectivePositions_ElectionID",
                table: "ElectivePositions",
                column: "ElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_PartyPolitical_ElectionID",
                table: "PartyPolitical",
                column: "ElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_PartyPolitical_siglasPartyPolitical",
                table: "PartyPolitical",
                column: "siglasPartyPolitical",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PartyPoliticalAliance_PartyPoliticalId",
                table: "PartyPoliticalAliance",
                column: "PartyPoliticalId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalLeader_ElectionID",
                table: "PoliticalLeader",
                column: "ElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalLeader_siglasPartyPolitical",
                table: "PoliticalLeader",
                column: "siglasPartyPolitical",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalLeader_userName",
                table: "PoliticalLeader",
                column: "userName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolUsers_rolID",
                table: "RolUsers",
                column: "rolID");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsers_userId",
                table: "RolUsers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_candidatosID",
                table: "Votes",
                column: "candidatosID");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_citizensID",
                table: "Votes",
                column: "citizensID");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ElectionID",
                table: "Votes",
                column: "ElectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_partyPoliticalsId",
                table: "Votes",
                column: "partyPoliticalsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartyPoliticalAliance");

            migrationBuilder.DropTable(
                name: "PoliticalLeader");

            migrationBuilder.DropTable(
                name: "RolUsers");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "AliancePolitical");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ElectivePositions");

            migrationBuilder.DropTable(
                name: "PartyPolitical");

            migrationBuilder.DropTable(
                name: "Election");
        }
    }
}
