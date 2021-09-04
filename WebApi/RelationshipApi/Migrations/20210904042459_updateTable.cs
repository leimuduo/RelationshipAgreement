using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RelationshipApi.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FamilyId",
                table: "Tokens",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IssuerId",
                table: "Tokens",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_FamilyId",
                table: "Tokens",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_IssuerId",
                table: "Tokens",
                column: "IssuerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Families_FamilyId",
                table: "Tokens",
                column: "FamilyId",
                principalTable: "Families",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Members_IssuerId",
                table: "Tokens",
                column: "IssuerId",
                principalTable: "Members",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Families_FamilyId",
                table: "Tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Members_IssuerId",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_FamilyId",
                table: "Tokens");

            migrationBuilder.DropIndex(
                name: "IX_Tokens_IssuerId",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "IssuerId",
                table: "Tokens");
        }
    }
}
