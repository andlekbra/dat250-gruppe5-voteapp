using Microsoft.EntityFrameworkCore.Migrations;

namespace VoteApp.DataAccess.Migrations
{
    public partial class addOwnerIdToPollTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollTemplates_VoterProfiles_CreatorId",
                table: "PollTemplates");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "PollTemplates",
                newName: "VoterProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_PollTemplates_CreatorId",
                table: "PollTemplates",
                newName: "IX_PollTemplates_VoterProfileId");

            migrationBuilder.AddColumn<string>(
                name: "ownerId",
                table: "PollTemplates",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PollTemplates_VoterProfiles_VoterProfileId",
                table: "PollTemplates",
                column: "VoterProfileId",
                principalTable: "VoterProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollTemplates_VoterProfiles_VoterProfileId",
                table: "PollTemplates");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "PollTemplates");

            migrationBuilder.RenameColumn(
                name: "VoterProfileId",
                table: "PollTemplates",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_PollTemplates_VoterProfileId",
                table: "PollTemplates",
                newName: "IX_PollTemplates_CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PollTemplates_VoterProfiles_CreatorId",
                table: "PollTemplates",
                column: "CreatorId",
                principalTable: "VoterProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
