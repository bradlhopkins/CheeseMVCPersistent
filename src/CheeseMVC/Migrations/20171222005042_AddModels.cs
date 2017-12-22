﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CheeseMVC.Migrations
{
    public partial class AddModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheeses_CheeseCategory_CategoryID",
                table: "Cheeses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CheeseCategory",
                table: "CheeseCategory");

            migrationBuilder.RenameTable(
                name: "CheeseCategory",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CheeseMenus",
                columns: table => new
                {
                    CheeseID = table.Column<int>(nullable: false),
                    MenuID = table.Column<int>(nullable: false),
                    CheeseCategoryID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheeseMenus", x => new { x.CheeseID, x.MenuID });
                    table.ForeignKey(
                        name: "FK_CheeseMenus_Categories_CheeseCategoryID",
                        column: x => x.CheeseCategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheeseMenus_Cheeses_CheeseID",
                        column: x => x.CheeseID,
                        principalTable: "Cheeses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheeseMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheeseMenus_CheeseCategoryID",
                table: "CheeseMenus",
                column: "CheeseCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CheeseMenus_MenuID",
                table: "CheeseMenus",
                column: "MenuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheeses_Categories_CategoryID",
                table: "Cheeses",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cheeses_Categories_CategoryID",
                table: "Cheeses");

            migrationBuilder.DropTable(
                name: "CheeseMenus");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "CheeseCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheeseCategory",
                table: "CheeseCategory",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cheeses_CheeseCategory_CategoryID",
                table: "Cheeses",
                column: "CategoryID",
                principalTable: "CheeseCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
