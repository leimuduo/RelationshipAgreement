using Microsoft.EntityFrameworkCore.Migrations;

namespace RelationshipApi.Migrations
{
    public partial class InitiateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IssuerDisplayName",
                table: "Tokens",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberDisplayName",
                table: "Tokens",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Members",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Members",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssuerDisplayName",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "MemberDisplayName",
                table: "Tokens");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Members");
        }
    }
}
