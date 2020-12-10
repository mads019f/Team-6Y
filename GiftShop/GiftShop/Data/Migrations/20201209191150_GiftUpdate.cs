using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GiftShop.Data.Migrations
{
    public partial class GiftUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    GiftID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    BoyGift = table.Column<bool>(nullable: false),
                    GirlGift = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.GiftID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gifts");
        }
    }
}
