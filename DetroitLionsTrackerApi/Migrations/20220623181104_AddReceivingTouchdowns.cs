using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DetroitLionsTrackerApi.Migrations
{
    public partial class AddReceivingTouchdowns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceivingTouchdowns",
                table: "OffensiveGameStats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivingTouchdowns",
                table: "OffensiveGameStats");
        }
    }
}
