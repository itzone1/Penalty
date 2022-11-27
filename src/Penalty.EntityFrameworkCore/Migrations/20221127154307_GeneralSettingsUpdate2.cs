using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Penalty.Migrations
{
    public partial class GeneralSettingsUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PaidForUser",
                table: "InvitedUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "BalancePerUser",
                table: "GeneralSettings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "DefaultCurrency",
                table: "GeneralSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaidForUser",
                table: "InvitedUsers");

            migrationBuilder.DropColumn(
                name: "BalancePerUser",
                table: "GeneralSettings");

            migrationBuilder.DropColumn(
                name: "DefaultCurrency",
                table: "GeneralSettings");
        }
    }
}
