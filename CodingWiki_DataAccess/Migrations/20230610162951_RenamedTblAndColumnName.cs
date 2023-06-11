using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenamedTblAndColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "tbl_genres");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "tbl_book");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "tbl_genres",
                newName: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_genres",
                table: "tbl_genres",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_book",
                table: "tbl_book",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_genres",
                table: "tbl_genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_book",
                table: "tbl_book");

            migrationBuilder.RenameTable(
                name: "tbl_genres",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "tbl_book",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "GenreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookId");
        }
    }
}
