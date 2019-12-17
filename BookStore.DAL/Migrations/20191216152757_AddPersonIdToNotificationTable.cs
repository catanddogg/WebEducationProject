using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DAL.Migrations
{
    public partial class AddPersonIdToNotificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PersonId",
                table: "Notifications",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Persons_PersonId",
                table: "Notifications",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Persons_PersonId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_PersonId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Notifications");
        }
    }
}
