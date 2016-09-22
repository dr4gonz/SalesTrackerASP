using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesTrackerASP.Migrations
{
    public partial class RemoveExplicitForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsSales_Items_ItemId",
                table: "ItemsSales");

            migrationBuilder.DropIndex(
                name: "IX_ItemsSales_ItemId",
                table: "ItemsSales");

            migrationBuilder.AddColumn<int>(
                name: "ItemId1",
                table: "ItemsSales",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemsSales_ItemId1",
                table: "ItemsSales",
                column: "ItemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsSales_Items_ItemId1",
                table: "ItemsSales",
                column: "ItemId1",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsSales_Items_ItemId1",
                table: "ItemsSales");

            migrationBuilder.DropIndex(
                name: "IX_ItemsSales_ItemId1",
                table: "ItemsSales");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "ItemsSales");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsSales_ItemId",
                table: "ItemsSales",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsSales_Items_ItemId",
                table: "ItemsSales",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
