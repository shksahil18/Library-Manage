using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddReturnDateToBorrow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BorrowDateTime",
                table: "Borrows",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "BorrowDateTime",
                table: "BorrowModel",
                newName: "BorrowDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDate",
                table: "Borrows",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "Borrows");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "Borrows",
                newName: "BorrowDateTime");

            migrationBuilder.RenameColumn(
                name: "BorrowDate",
                table: "BorrowModel",
                newName: "BorrowDateTime");
        }
    }
}
