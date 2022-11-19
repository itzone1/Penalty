using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Penalty.Migrations
{
    public partial class general_settings_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MerchantSecretKey",
                table: "GeneralSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MerchantShop",
                table: "GeneralSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MerchantUrl",
                table: "GeneralSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaySystemId",
                table: "Bets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Bets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PaySystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MerchantUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    m_shop = table.Column<int>(type: "int", nullable: false),
                    m_orderid = table.Column<int>(type: "int", nullable: false),
                    m_amount = table.Column<double>(type: "float", nullable: false),
                    m_curr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    m_desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    m_key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sign = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_PaySystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaySystems_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_PaySystemId",
                table: "Bets",
                column: "PaySystemId");

            migrationBuilder.CreateIndex(
                name: "IX_PaySystems_UserId",
                table: "PaySystems",
                column: "UserId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Bets_PaySystems_PaySystemId",
            //    table: "Bets",
            //    column: "PaySystemId",
            //    principalTable: "PaySystems",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_PaySystems_PaySystemId",
                table: "Bets");

            migrationBuilder.DropTable(
                name: "PaySystems");

            migrationBuilder.DropIndex(
                name: "IX_Bets_PaySystemId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "MerchantSecretKey",
                table: "GeneralSettings");

            migrationBuilder.DropColumn(
                name: "MerchantShop",
                table: "GeneralSettings");

            migrationBuilder.DropColumn(
                name: "MerchantUrl",
                table: "GeneralSettings");

            migrationBuilder.DropColumn(
                name: "PaySystemId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Bets");
        }
    }
}
