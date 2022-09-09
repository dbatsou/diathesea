using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storage.Migrations
{
    public partial class AddStateColumnToActivityEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "ActivityEntry",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEntry_StateId",
                table: "ActivityEntry",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_State_StateId",
                table: "ActivityEntry",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_State_StateId",
                table: "ActivityEntry");

            migrationBuilder.DropIndex(
                name: "IX_ActivityEntry_StateId",
                table: "ActivityEntry");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "ActivityEntry");
        }
    }
}
