using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramBot.Database.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Chats",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "Chats",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
