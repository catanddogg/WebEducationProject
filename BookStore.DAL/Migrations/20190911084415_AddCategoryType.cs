using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DAL.Migrations
{
    public partial class AddCategoryType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "FirstCategoryType",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondCategoryType",
                table: "Categories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrirdCategoryType",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstCategoryType",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SecondCategoryType",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "TrirdCategoryType",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryType",
                table: "Categories",
                nullable: false,
                defaultValue: 0);
        }
    }
}
