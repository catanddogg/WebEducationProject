using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DAL.Migrations
{
    public partial class AddResetPasswordToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ResetPasswordToken",
                table: "Persons",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetPasswordToken",
                table: "Persons");
        }
    }
}
