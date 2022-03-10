using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FullCal.Data.Migrations
{
    public partial class processnamechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Processes_ProcessId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Events",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ProcName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Processes_ProcessId",
                table: "Events",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Processes_ProcessId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ProcName",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Processes_ProcessId",
                table: "Events",
                column: "ProcessId",
                principalTable: "Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
