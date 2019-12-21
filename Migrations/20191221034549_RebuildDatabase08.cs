using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCapellaKM_05.Migrations
{
    public partial class RebuildDatabase08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PubWork_Author_AuthorID",
                table: "PubWork");

            migrationBuilder.DropForeignKey(
                name: "FK_PubWork_Publication_PublicationID",
                table: "PubWork");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationID",
                table: "PubWork",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "PubWork",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PubWork_Author_AuthorID",
                table: "PubWork",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PubWork_Publication_PublicationID",
                table: "PubWork",
                column: "PublicationID",
                principalTable: "Publication",
                principalColumn: "PublicationID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PubWork_Author_AuthorID",
                table: "PubWork");

            migrationBuilder.DropForeignKey(
                name: "FK_PubWork_Publication_PublicationID",
                table: "PubWork");

            migrationBuilder.AlterColumn<int>(
                name: "PublicationID",
                table: "PubWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "PubWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PubWork_Author_AuthorID",
                table: "PubWork",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PubWork_Publication_PublicationID",
                table: "PubWork",
                column: "PublicationID",
                principalTable: "Publication",
                principalColumn: "PublicationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
