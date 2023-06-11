using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class oneToManyRelation_Book_Publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "tbl_book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "tbl_book",
                keyColumn: "BookId",
                keyValue: 1,
                column: "Publisher_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "tbl_book",
                keyColumn: "BookId",
                keyValue: 2,
                column: "Publisher_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "tbl_book",
                keyColumn: "BookId",
                keyValue: 3,
                column: "Publisher_Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "tbl_book",
                keyColumn: "BookId",
                keyValue: 4,
                column: "Publisher_Id",
                value: 3);

            migrationBuilder.InsertData(
                table: "tbl_publishers",
                columns: new[] { "Publisher_Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Chicago", "Pub 1 Jimmy" },
                    { 2, "New York", "Pub 2 Jimmy" },
                    { 3, "Singapore", "Pub 3 Jimmy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_book_Publisher_Id",
                table: "tbl_book",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_book_tbl_publishers_Publisher_Id",
                table: "tbl_book",
                column: "Publisher_Id",
                principalTable: "tbl_publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_book_tbl_publishers_Publisher_Id",
                table: "tbl_book");

            migrationBuilder.DropIndex(
                name: "IX_tbl_book_Publisher_Id",
                table: "tbl_book");

            migrationBuilder.DeleteData(
                table: "tbl_publishers",
                keyColumn: "Publisher_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tbl_publishers",
                keyColumn: "Publisher_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tbl_publishers",
                keyColumn: "Publisher_Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "tbl_book");
        }
    }
}
