using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerAcountManagement.Storage.Migrations
{
    public partial class withbalanceint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Balance",
                table: "Acounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Balance",
                table: "Acounts",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
