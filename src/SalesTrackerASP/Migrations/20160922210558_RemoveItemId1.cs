using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesTrackerASP.Migrations
{
    public partial class RemoveItemId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsSales_Items_ItemId1",
                table: "ItemsSales");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsSales_Sales_SaleId",
                table: "ItemsSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsSales",
                table: "ItemsSales");

            migrationBuilder.DropIndex(
                name: "IX_ItemsSales_ItemId1",
                table: "ItemsSales");

            migrationBuilder.DropColumn(
                name: "ItemId1",
                table: "ItemsSales");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemsSales",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "ItemsSales",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemsSales",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsSales",
                table: "ItemsSales",
                column: "Id");

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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsSales_Sales_SaleId",
                table: "ItemsSales",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsSales_Items_ItemId",
                table: "ItemsSales");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsSales_Sales_SaleId",
                table: "ItemsSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsSales",
                table: "ItemsSales");

            migrationBuilder.DropIndex(
                name: "IX_ItemsSales_ItemId",
                table: "ItemsSales");

            migrationBuilder.AddColumn<int>(
                name: "ItemId1",
                table: "ItemsSales",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "ItemsSales",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemsSales",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemsSales",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsSales",
                table: "ItemsSales",
                columns: new[] { "ItemId", "SaleId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsSales_Sales_SaleId",
                table: "ItemsSales",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
