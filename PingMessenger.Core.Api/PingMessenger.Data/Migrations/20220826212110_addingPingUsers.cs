using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingMessenger.Data.Migrations
{
    public partial class addingPingUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_PingUser_Conversation_Id",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PingUser",
                table: "PingUser");

            migrationBuilder.RenameTable(
                name: "PingUser",
                newName: "PingUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PingUsers",
                table: "PingUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_PingUsers_Conversation_Id",
                table: "Participants",
                column: "Conversation_Id",
                principalTable: "PingUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_PingUsers_Conversation_Id",
                table: "Participants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PingUsers",
                table: "PingUsers");

            migrationBuilder.RenameTable(
                name: "PingUsers",
                newName: "PingUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PingUser",
                table: "PingUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_PingUser_Conversation_Id",
                table: "Participants",
                column: "Conversation_Id",
                principalTable: "PingUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
