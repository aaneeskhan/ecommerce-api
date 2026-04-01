using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ConfirmationCode", "CreatedOn", "Email", "Password", "PhoneNo", "Salt", "UserRole", "UserStatus" },
                values: new object[] { new Guid("019d237c-86bf-78c1-aa52-ef2091ce5c25"), "", new DateTimeOffset(new DateTime(2026, 3, 31, 23, 44, 49, 814, DateTimeKind.Unspecified).AddTicks(2002), new TimeSpan(0, 5, 30, 0, 0)), "sania@gmail.com", "$2a$11$YOtZkxWhHmwRR4XiiwA1PO8WGZyTnzJXue6ZFesAsJiB8a3bzbXTi", "9797893466", "$2a$11$YOtZkxWhHmwRR4XiiwA1PO", 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
