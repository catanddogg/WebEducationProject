using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DAL.Migrations
{
    public partial class RenameAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameAvtor",
                table: "Avtors",
                newName: "NameAuthor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameAuthor",
                table: "Avtors",
                newName: "NameAvtor");
        }
    }
}
