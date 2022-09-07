using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerAcountManagement.Storage.Migrations
{
    public partial class balanceint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Customers",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Customers", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Acounts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CustomerId = table.Column<int>(type: "int", nullable: false),
            //        OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Balance = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Acounts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Acounts_Customers_CustomerId",
            //            column: x => x.CustomerId,
            //            principalTable: "Customers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Acounts_CustomerId",
            //    table: "Acounts",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Customers_Email",
            //    table: "Customers",
            //    column: "Email",
            //    unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acounts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
