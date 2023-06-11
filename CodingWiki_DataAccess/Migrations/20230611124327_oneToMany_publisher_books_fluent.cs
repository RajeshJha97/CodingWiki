using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class oneToMany_publisher_books_fluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Fluent_Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Fluent_BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Books_Publisher_Id",
                table: "Fluent_Books",
                column: "Publisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookDetails_BookId",
                table: "Fluent_BookDetails",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Books_BookId",
                table: "Fluent_BookDetails",
                column: "BookId",
                principalTable: "Fluent_Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_Publisher_Id",
                table: "Fluent_Books",
                column: "Publisher_Id",
                principalTable: "Fluent_Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Books_BookId",
                table: "Fluent_BookDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_Publisher_Id",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Books_Publisher_Id",
                table: "Fluent_Books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookDetails_BookId",
                table: "Fluent_BookDetails");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Fluent_Books");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Fluent_BookDetails");
        }
    }
}
