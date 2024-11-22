using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoteFCSoccer.Migrations
{
    /// <inheritdoc />
    public partial class SuppressionAttributEquipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "League",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "LeaguePseudo",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "Pseudo",
                table: "Equipe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "League",
                table: "Equipe",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeaguePseudo",
                table: "Equipe",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pseudo",
                table: "Equipe",
                type: "TEXT",
                nullable: true);
        }
    }
}
