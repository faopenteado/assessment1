using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventim.ExpensesAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpensesGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "_ExpensesGroupsPeople",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ExpensesGroupsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ExpensesGroupsPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ExpensesGroupsPeople_ExpensesGroups_ExpensesGroupsId",
                        column: x => x.ExpensesGroupsId,
                        principalTable: "ExpensesGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpensesGroupsPeopleId = table.Column<long>(type: "bigint", nullable: false),
                    ExpensesGroupsId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpensesGroups_ExpensesGroupsId",
                        column: x => x.ExpensesGroupsId,
                        principalTable: "ExpensesGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Expenses__ExpensesGroupsPeople_ExpensesGroupsPeopleId",
                        column: x => x.ExpensesGroupsPeopleId,
                        principalTable: "_ExpensesGroupsPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_People = table.Column<int>(type: "int", nullable: false),
                    expensesGroupsPeopleId = table.Column<long>(type: "bigint", nullable: false),
                    Id_ExpenseGroup = table.Column<int>(type: "int", nullable: false),
                    ExpensesGroupsId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_ExpensesGroups_ExpensesGroupsId",
                        column: x => x.ExpensesGroupsId,
                        principalTable: "ExpensesGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Payments__ExpensesGroupsPeople_expensesGroupsPeopleId",
                        column: x => x.expensesGroupsPeopleId,
                        principalTable: "_ExpensesGroupsPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX__ExpensesGroupsPeople_ExpensesGroupsId",
                table: "_ExpensesGroupsPeople",
                column: "ExpensesGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpensesGroupsId",
                table: "Expenses",
                column: "ExpensesGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpensesGroupsPeopleId",
                table: "Expenses",
                column: "ExpensesGroupsPeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ExpensesGroupsId",
                table: "Payments",
                column: "ExpensesGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_expensesGroupsPeopleId",
                table: "Payments",
                column: "expensesGroupsPeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "_ExpensesGroupsPeople");

            migrationBuilder.DropTable(
                name: "ExpensesGroups");
        }
    }
}
