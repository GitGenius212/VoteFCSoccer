using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoteFCSoccer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibelleVote",
                columns: table => new
                {
                    LibelleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibelleVote", x => x.LibelleId);
                });

            migrationBuilder.CreateTable(
                name: "Candidat",
                columns: table => new
                {
                    CandidatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Logo = table.Column<string>(type: "TEXT", nullable: true),
                    LibelleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidat", x => x.CandidatId);
                    table.ForeignKey(
                        name: "FK_Candidat_LibelleVote_LibelleId",
                        column: x => x.LibelleId,
                        principalTable: "LibelleVote",
                        principalColumn: "LibelleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    voteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Votant = table.Column<string>(type: "TEXT", nullable: true),
                    CandidatId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.voteId);
                    table.ForeignKey(
                        name: "FK_Vote_Candidat_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Candidat",
                        principalColumn: "CandidatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidat_LibelleId",
                table: "Candidat",
                column: "LibelleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_CandidatId",
                table: "Vote",
                column: "CandidatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Candidat");

            migrationBuilder.DropTable(
                name: "LibelleVote");
        }
    }
}
