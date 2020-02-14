using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyWallet.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseReport",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    TypeC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseReport", x => x.ItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseReport");
        }
    }
}
