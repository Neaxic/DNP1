using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    public partial class _1_bookEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorsId",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenresId",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorsId",
                table: "Books",
                column: "AuthorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenresId",
                table: "Books",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorsId",
                table: "Books",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "AuthorsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_GenresId",
                table: "Books",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "GenresId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorsId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_GenresId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorsId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_GenresId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorsId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "GenresId",
                table: "Books");
        }
    }
}
