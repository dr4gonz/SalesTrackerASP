using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SalesTrackerASP.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Sales_SaleId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsSales",
                table: "ItemsSales");

            migrationBuilder.DropIndex(
                name: "IX_Items_SaleId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemsSales",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsSales",
                table: "ItemsSales",
                columns: new[] { "ItemId", "SaleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsSales",
                table: "ItemsSales");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "Items",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemsSales",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsSales",
                table: "ItemsSales",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SaleId",
                table: "Items",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Sales_SaleId",
                table: "Items",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
