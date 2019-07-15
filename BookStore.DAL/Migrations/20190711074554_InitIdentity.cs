using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DAL.Migrations
{
    public partial class InitIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    createTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avtors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    NameAvtor = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avtors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avtors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    CategoryType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Name", "Path" },
                values: new object[,]
                {
                    { 1, "test", null },
                    { 2, "test", null },
                    { 3, "test", null },
                    { 4, "test", null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Message", "UserName", "createTime" },
                values: new object[] { 1, "Hello", "user1", new DateTime(2019, 7, 11, 10, 45, 54, 199, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "FirstName", "Login", "Password", "RefreshToken", "Role", "SecondName" },
                values: new object[,]
                {
                    { 1, 18, "user1", "TestUser1", "12345", null, "user", "user2" },
                    { 2, 27, "user3", "TestUser3", "1234", null, "user", "user4" },
                    { 3, 36, "user5", "TestUser2", "123456", null, "admin", "user6" }
                });

            migrationBuilder.InsertData(
                table: "Avtors",
                columns: new[] { "Id", "BookId", "NameAvtor", "Publisher" },
                values: new object[,]
                {
                    { 1, 1, "test", "test2" },
                    { 2, 2, "test", "test2" },
                    { 3, 3, "test", "test2" },
                    { 4, 4, "test", "test2" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "BookId", "CategoryType" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 3 },
                    { 3, 3, 6 },
                    { 4, 4, 24 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avtors_BookId",
                table: "Avtors",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_BookId",
                table: "Categories",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avtors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
