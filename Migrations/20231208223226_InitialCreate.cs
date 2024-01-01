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
                name: "Equipe",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", nullable: true),
                    Logo = table.Column<string>(type: "TEXT", nullable: true),
                    Pseudo = table.Column<string>(type: "TEXT", nullable: true),
                    League = table.Column<string>(type: "TEXT", nullable: true),
                    LeaguePseudo = table.Column<string>(type: "TEXT", nullable: true),
                    LibelleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.EquipeId);
                    table.ForeignKey(
                        name: "FK_Equipe_LibelleVote_LibelleId",
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
                    EquipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => x.voteId);
                    table.ForeignKey(
                        name: "FK_Vote_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "EquipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_LibelleId",
                table: "Equipe",
                column: "LibelleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_EquipeId",
                table: "Vote",
                column: "EquipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "LibelleVote");
        }
    }
}
