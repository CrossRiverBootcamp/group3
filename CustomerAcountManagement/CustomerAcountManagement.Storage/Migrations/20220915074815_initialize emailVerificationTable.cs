using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerAcountManagement.Storage.Migrations
{
    public partial class initializeemailVerificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailVerifications",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    VerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerifications", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailVerifications");
        }
    }
}
