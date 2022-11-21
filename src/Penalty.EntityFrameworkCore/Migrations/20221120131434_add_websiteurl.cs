using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Penalty.Migrations
{
    public partial class add_websiteurl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WebsiteDeafultLink",
                table: "GeneralSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WebsiteDeafultLink",
                table: "GeneralSettings");
        }
    }
}
