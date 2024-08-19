using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYEXPENSES.API.Migrations
{
    public partial class fixincomeFK_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Incomes");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_SubCategoryId",
                table: "Expenses",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_SubCategories_SubCategoryId",
                table: "Expenses",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_SubCategories_SubCategoryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_SubCategoryId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Incomes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
