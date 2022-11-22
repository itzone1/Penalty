using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Penalty.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_PayMethod_PayMethodId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_PayMethod_AbpUsers_UserId",
                table: "PayMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayMethod",
                table: "PayMethod");

            migrationBuilder.RenameTable(
                name: "PayMethod",
                newName: "PayMethods");

            migrationBuilder.RenameIndex(
                name: "IX_PayMethod_UserId",
                table: "PayMethods",
                newName: "IX_PayMethods_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayMethods",
                table: "PayMethods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_PayMethods_PayMethodId",
                table: "Bets",
                column: "PayMethodId",
                principalTable: "PayMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayMethods_AbpUsers_UserId",
                table: "PayMethods",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_PayMethods_PayMethodId",
                table: "Bets");

            migrationBuilder.DropForeignKey(
                name: "FK_PayMethods_AbpUsers_UserId",
                table: "PayMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PayMethods",
                table: "PayMethods");

            migrationBuilder.RenameTable(
                name: "PayMethods",
                newName: "PayMethod");

            migrationBuilder.RenameIndex(
                name: "IX_PayMethods_UserId",
                table: "PayMethod",
                newName: "IX_PayMethod_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PayMethod",
                table: "PayMethod",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_PayMethod_PayMethodId",
                table: "Bets",
                column: "PayMethodId",
                principalTable: "PayMethod",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PayMethod_AbpUsers_UserId",
                table: "PayMethod",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
