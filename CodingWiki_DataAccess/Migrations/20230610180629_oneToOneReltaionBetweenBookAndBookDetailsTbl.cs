using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class oneToOneReltaionBetweenBookAndBookDetailsTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "tbl_bookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_bookDetails_BookId",
                table: "tbl_bookDetails",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_bookDetails_tbl_book_BookId",
                table: "tbl_bookDetails",
                column: "BookId",
                principalTable: "tbl_book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_bookDetails_tbl_book_BookId",
                table: "tbl_bookDetails");

            migrationBuilder.DropIndex(
                name: "IX_tbl_bookDetails_BookId",
                table: "tbl_bookDetails");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "tbl_bookDetails");
        }
    }
}
