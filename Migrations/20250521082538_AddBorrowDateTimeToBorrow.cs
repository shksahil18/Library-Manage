using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddBorrowDateTimeToBorrow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_LibraryBranches_LibraryBranchId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BorrowDate",
                table: "Borrows",
                newName: "BorrowDateTime");

            migrationBuilder.RenameColumn(
                name: "BorrowDate",
                table: "BorrowModel",
                newName: "BorrowDateTime");

            migrationBuilder.AlterColumn<int>(
                name: "LibraryBranchId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_LibraryBranches_LibraryBranchId",
                table: "Books",
                column: "LibraryBranchId",
                principalTable: "LibraryBranches",
                principalColumn: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowDateTime",
                table: "Borrows",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2025, 1, 1)); // or default DateTime
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_LibraryBranches_LibraryBranchId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BorrowDateTime",
                table: "Borrows",
                newName: "BorrowDate");

            migrationBuilder.RenameColumn(
                name: "BorrowDateTime",
                table: "BorrowModel",
                newName: "BorrowDate");

            migrationBuilder.AlterColumn<int>(
                name: "LibraryBranchId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_LibraryBranches_LibraryBranchId",
                table: "Books",
                column: "LibraryBranchId",
                principalTable: "LibraryBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
