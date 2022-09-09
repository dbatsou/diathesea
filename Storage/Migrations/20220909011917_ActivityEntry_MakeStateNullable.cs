using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Storage.Migrations
{
    public partial class ActivityEntry_MakeStateNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_State_StateId",
                table: "ActivityEntry");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "ActivityEntry",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_State_StateId",
                table: "ActivityEntry",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityEntry_State_StateId",
                table: "ActivityEntry");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "ActivityEntry",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityEntry_State_StateId",
                table: "ActivityEntry",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
