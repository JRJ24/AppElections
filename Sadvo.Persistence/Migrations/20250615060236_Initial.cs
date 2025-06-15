using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sadvo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    isActiveElection = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Election", x => x.ElectionId);
                });

            migrationBuilder.CreateTable(
                name: "RolUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<int>(type: "int", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rolName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsers", x => x.Id);
                    table.UniqueConstraint("AK_RolUsers_rolName", x => x.rolName);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteNumber = table.Column<int>(type: "int", nullable: false),
                    citizensID = table.Column<int>(type: "int", nullable: false),
                    citizensName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    siglasPartyPolitical = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    candidatosName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.ID);
                    table.UniqueConstraint("UQ_CitizensID", x => x.citizensID);
                    table.UniqueConstraint("UQ_SIGLASPARTYPOLITICAL", x => x.siglasPartyPolitical);
                    table.UniqueConstraint("UQ_VOTENUMBER", x => x.VoteNumber);
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
                    table.ForeignKey(
                        name: "FK_Roles_RolUsers_NameRol",
                        column: x => x.NameRol,
                        principalTable: "RolUsers",
                        principalColumn: "rolName",
                        onDelete: ReferentialAction.Cascade);
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
                    RolUsersId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("UQ_KEY_EMAIL", x => x.email);
                    table.UniqueConstraint("UQ_KEY_USERNAME", x => x.userName);
                    table.ForeignKey(
                        name: "FK_Users_RolUsers_RolUsersId",
                        column: x => x.RolUsersId,
                        principalTable: "RolUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Citizens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    numberIdentity = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    isVoted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CITIZENDSID",
                        column: x => x.Id,
                        principalTable: "Votes",
                        principalColumn: "citizensID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartyPolitical",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    siglasPartyPolitical = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyPolitical", x => x.Id);
                    table.UniqueConstraint("AK_PartyPolitical_siglasPartyPolitical", x => x.siglasPartyPolitical);
                    table.ForeignKey(
                        name: "FK_PartyPolitical_Election_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Election",
                        principalColumn: "ElectionId");
                    table.ForeignKey(
                        name: "FK_SIGLASPARTYPOLITICAL",
                        column: x => x.siglasPartyPolitical,
                        principalTable: "Votes",
                        principalColumn: "siglasPartyPolitical",
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
                    partyPoliticalId = table.Column<int>(type: "int", nullable: true),
                    electivePositionId = table.Column<int>(type: "int", nullable: true),
                    votesID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatos", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_Candidatos_Votes_votesID",
                        column: x => x.votesID,
                        principalTable: "Votes",
                        principalColumn: "ID");
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
                    siglasPartyPolitical = table.Column<string>(type: "nvarchar(10)", nullable: false)
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
                        name: "FK_USERNAME_POLITICAL_LEADERS",
                        column: x => x.userName,
                        principalTable: "Users",
                        principalColumn: "userName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_electivePositionId",
                table: "Candidatos",
                column: "electivePositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_partyPoliticalId",
                table: "Candidatos",
                column: "partyPoliticalId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidatos_votesID",
                table: "Candidatos",
                column: "votesID");

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_email",
                table: "Citizens",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_numberIdentity",
                table: "Citizens",
                column: "numberIdentity",
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
                name: "IX_PartyPolitical_ElectionId",
                table: "PartyPolitical",
                column: "ElectionId");

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
                name: "IX_Users_RolUsersId",
                table: "Users",
                column: "RolUsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatos");

            migrationBuilder.DropTable(
                name: "Citizens");

            migrationBuilder.DropTable(
                name: "PartyPoliticalAliance");

            migrationBuilder.DropTable(
                name: "PoliticalLeader");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ElectivePositions");

            migrationBuilder.DropTable(
                name: "AliancePolitical");

            migrationBuilder.DropTable(
                name: "PartyPolitical");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Election");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "RolUsers");
        }
    }
}
