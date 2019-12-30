using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCapellaKM_05.Migrations
{
    public partial class RebuildDb01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PubWorkNote",
                table: "PubWork");

            migrationBuilder.AddColumn<string>(
                name: "PubWorkKeyPhrases",
                table: "PubWork",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PubWorkNotes",
                table: "PubWork",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PubWorkYear",
                table: "PubWork",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PubWorkKeyPhrases",
                table: "PubWork");

            migrationBuilder.DropColumn(
                name: "PubWorkNotes",
                table: "PubWork");

            migrationBuilder.DropColumn(
                name: "PubWorkYear",
                table: "PubWork");

            migrationBuilder.AddColumn<string>(
                name: "PubWorkNote",
                table: "PubWork",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
