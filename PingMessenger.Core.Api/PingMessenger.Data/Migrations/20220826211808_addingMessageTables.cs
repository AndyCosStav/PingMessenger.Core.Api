using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingMessenger.Data.Migrations
{
    public partial class addingMessageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ConversationId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PingUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PingUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Conversation_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_MessageId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_Conversation_Id",
                        column: x => x.Conversation_Id,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conversation_Id = table.Column<int>(type: "int", nullable: false),
                    PingUser_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ParticipantsId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participants_Conversations_Conversation_Id",
                        column: x => x.Conversation_Id,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participants_PingUser_Conversation_Id",
                        column: x => x.Conversation_Id,
                        principalTable: "PingUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_Conversation_Id",
                table: "Messages",
                column: "Conversation_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_Conversation_Id",
                table: "Participants",
                column: "Conversation_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "PingUser");
        }
    }
}
