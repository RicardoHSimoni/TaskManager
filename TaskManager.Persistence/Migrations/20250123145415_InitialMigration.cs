using System;
using Microsoft.EntityFrameworkCore.Migrations;
using TaskManager.Models;

#nullable disable

namespace TaskManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "RecurringLabor",
                columns: table => new
                {
                    LaborId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    //DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<Category>(type: "INTEGER", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    Recurence =table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringLabor", x => x.LaborId);
                    table.ForeignKey(
                        name: "FK_RecurringLabor_Categories_CategoryId",
                        column: x => x.Category,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SimpleLabor",
                columns: table => new
                {
                    LaborId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    //DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<Category>(type: "INTEGER", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimpleLabor", x => x.LaborId);
                    table.ForeignKey(
                        name: "FK_SimpleLabor_Categories_CategoryId",
                        column: x => x.Category,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecurringLabor_CategoryId",
                table: "RecurringLabor",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SimpleLabor_CategoryId",
                table: "SimpleLabor",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecurringLabor");

            migrationBuilder.DropTable(
                name: "SimpleLabor");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
