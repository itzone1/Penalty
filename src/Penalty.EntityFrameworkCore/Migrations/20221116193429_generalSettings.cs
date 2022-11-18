using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Penalty.Migrations
{
    public partial class generalSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "PayMethod",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecretKey",
                table: "PayMethod",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "PayMethod",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "PayMethod",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LeagueApiKey",
                table: "League",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GeneralSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultODD = table.Column<double>(type: "float", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSettings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PayMethod_UserId",
                table: "PayMethod",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PayMethod_AbpUsers_UserId",
                table: "PayMethod",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PayMethod_AbpUsers_UserId",
                table: "PayMethod");

            migrationBuilder.DropTable(
                name: "GeneralSettings");

            migrationBuilder.DropIndex(
                name: "IX_PayMethod_UserId",
                table: "PayMethod");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "PayMethod");

            migrationBuilder.DropColumn(
                name: "SecretKey",
                table: "PayMethod");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PayMethod");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "PayMethod");

            migrationBuilder.DropColumn(
                name: "LeagueApiKey",
                table: "League");
        }
    }
}
