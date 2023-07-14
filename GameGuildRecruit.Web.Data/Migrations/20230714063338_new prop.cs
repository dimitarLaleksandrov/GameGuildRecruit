using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGuildRecruit.Web.Data.Migrations
{
    public partial class newprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGameHasView",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsGameHasView",
                table: "Games");
        }
    }
}
