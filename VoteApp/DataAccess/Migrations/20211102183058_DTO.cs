using Microsoft.EntityFrameworkCore.Migrations;

namespace VoteApp.DataAccess.Migrations
{
    public partial class DTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polls_VoteCounts_VoteCountId1",
                table: "Polls");

            migrationBuilder.RenameColumn(
                name: "VoteCountId1",
                table: "Polls",
                newName: "VoteCountId");

            migrationBuilder.RenameIndex(
                name: "IX_Polls_VoteCountId1",
                table: "Polls",
                newName: "IX_Polls_VoteCountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polls_VoteCounts_VoteCountId",
                table: "Polls",
                column: "VoteCountId",
                principalTable: "VoteCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polls_VoteCounts_VoteCountId",
                table: "Polls");

            migrationBuilder.RenameColumn(
                name: "VoteCountId",
                table: "Polls",
                newName: "VoteCountId1");

            migrationBuilder.RenameIndex(
                name: "IX_Polls_VoteCountId",
                table: "Polls",
                newName: "IX_Polls_VoteCountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Polls_VoteCounts_VoteCountId1",
                table: "Polls",
                column: "VoteCountId1",
                principalTable: "VoteCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
