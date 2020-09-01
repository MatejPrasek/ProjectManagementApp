using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagementApp.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserLogs_LogId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_LogId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LogId",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "Action",
                table: "UserLogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CommentId",
                table: "UserLogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "UserLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_CommentId",
                table: "UserLogs",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogs_Comments_CommentId",
                table: "UserLogs",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogs_Comments_CommentId",
                table: "UserLogs");

            migrationBuilder.DropIndex(
                name: "IX_UserLogs_CommentId",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "UserLogs");

            migrationBuilder.AddColumn<Guid>(
                name: "LogId",
                table: "Comments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LogId",
                table: "Comments",
                column: "LogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserLogs_LogId",
                table: "Comments",
                column: "LogId",
                principalTable: "UserLogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
