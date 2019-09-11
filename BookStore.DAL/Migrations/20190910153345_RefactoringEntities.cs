using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DAL.Migrations
{
    public partial class RefactoringEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avtors_Books_BookId",
                table: "Avtors");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Books_BookId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Avtors_BookId",
                table: "Avtors");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Avtors");

            migrationBuilder.RenameColumn(
                name: "createTime",
                table: "Comments",
                newName: "CreateDateTime");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Avtors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Avtors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Books_BookId",
                table: "Categories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Avtors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Books_BookId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CreateDateTime",
                table: "Comments",
                newName: "createTime");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Avtors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Avtors_BookId",
                table: "Avtors",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avtors_Books_BookId",
                table: "Avtors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Books_BookId",
                table: "Categories",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
