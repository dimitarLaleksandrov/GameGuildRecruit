using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGuildRecruit.Web.Data.Migrations
{
    public partial class Contact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ContactPlayers",
                newName: "GuildUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuildUserId",
                table: "ContactPlayers",
                newName: "UserId");
        }
    }
}
