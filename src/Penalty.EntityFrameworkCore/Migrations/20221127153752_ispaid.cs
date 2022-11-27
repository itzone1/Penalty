using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Penalty.Migrations
{
    public partial class ispaid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isActivated",
                table: "InvitedUsers",
                newName: "IsActivated");

            migrationBuilder.RenameColumn(
                name: "isPaid",
                table: "BetResults",
                newName: "IsPaid");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "InvitedUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "InvitedUsers");

            migrationBuilder.RenameColumn(
                name: "IsActivated",
                table: "InvitedUsers",
                newName: "isActivated");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "BetResults",
                newName: "isPaid");
        }
    }
}
