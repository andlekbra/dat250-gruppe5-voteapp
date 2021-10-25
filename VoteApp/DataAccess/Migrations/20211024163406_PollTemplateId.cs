using Microsoft.EntityFrameworkCore.Migrations;

namespace VoteApp.DataAccess.Migrations
{
    public partial class PollTemplateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polls_PollTemplates_TemplateId",
                table: "Polls");

            migrationBuilder.DropIndex(
                name: "IX_Polls_TemplateId",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "Polls");

            migrationBuilder.AddColumn<int>(
                name: "PollTemplateId",
                table: "Polls",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Polls_PollTemplateId",
                table: "Polls",
                column: "PollTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polls_PollTemplates_PollTemplateId",
                table: "Polls",
                column: "PollTemplateId",
                principalTable: "PollTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Polls_PollTemplates_PollTemplateId",
                table: "Polls");

            migrationBuilder.DropIndex(
                name: "IX_Polls_PollTemplateId",
                table: "Polls");

            migrationBuilder.DropColumn(
                name: "PollTemplateId",
                table: "Polls");

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "Polls",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Polls_TemplateId",
                table: "Polls",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Polls_PollTemplates_TemplateId",
                table: "Polls",
                column: "TemplateId",
                principalTable: "PollTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
