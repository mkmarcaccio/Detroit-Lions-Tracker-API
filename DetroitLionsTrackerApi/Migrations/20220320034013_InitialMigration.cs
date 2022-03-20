using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DetroitLionsTrackerApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Unit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false),
                    DepthChartOrder = table.Column<int>(type: "int", nullable: false),
                    IsOnRoster = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    SeasonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Record = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.SeasonId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeasonId = table.Column<long>(type: "bigint", nullable: false),
                    Opponent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Outcome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.GameId);
                    table.ForeignKey(
                        name: "FK_Game_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SeasonPlayers",
                columns: table => new
                {
                    SeasonPlayersId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SeasonId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonPlayers", x => x.SeasonPlayersId);
                    table.ForeignKey(
                        name: "FK_SeasonPlayers_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonPlayers_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DefensiveGameStats",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    Tackles = table.Column<int>(type: "int", nullable: false),
                    TacklesForLoss = table.Column<int>(type: "int", nullable: false),
                    Sacks = table.Column<int>(type: "int", nullable: false),
                    ForcedFumbles = table.Column<int>(type: "int", nullable: false),
                    FumblesRecovered = table.Column<int>(type: "int", nullable: false),
                    Interceptions = table.Column<int>(type: "int", nullable: false),
                    IntYards = table.Column<int>(type: "int", nullable: false),
                    PassesDeflected = table.Column<int>(type: "int", nullable: false),
                    Touchdowns = table.Column<int>(type: "int", nullable: false),
                    Safeties = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefensiveGameStats", x => new { x.GameId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_DefensiveGameStats_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DefensiveGameStats_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OffensiveGameStats",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    PassingAttempts = table.Column<int>(type: "int", nullable: false),
                    PassingCompletions = table.Column<int>(type: "int", nullable: false),
                    PassingYards = table.Column<int>(type: "int", nullable: false),
                    PassingTouchdowns = table.Column<int>(type: "int", nullable: false),
                    Interceptions = table.Column<int>(type: "int", nullable: false),
                    RushingAttempts = table.Column<int>(type: "int", nullable: false),
                    RushingYards = table.Column<int>(type: "int", nullable: false),
                    RushingTouchdowns = table.Column<int>(type: "int", nullable: false),
                    Fumbles = table.Column<int>(type: "int", nullable: false),
                    Receptions = table.Column<int>(type: "int", nullable: false),
                    ReceivingYards = table.Column<int>(type: "int", nullable: false),
                    Targets = table.Column<int>(type: "int", nullable: false),
                    Drops = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffensiveGameStats", x => new { x.GameId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_OffensiveGameStats_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OffensiveGameStats_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SpecialTeamsGameStats",
                columns: table => new
                {
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    FGAttempts = table.Column<int>(type: "int", nullable: false),
                    FGMade = table.Column<int>(type: "int", nullable: false),
                    XPAttempts = table.Column<int>(type: "int", nullable: false),
                    XPMade = table.Column<int>(type: "int", nullable: false),
                    Punts = table.Column<int>(type: "int", nullable: false),
                    PuntYards = table.Column<int>(type: "int", nullable: false),
                    KickReturns = table.Column<int>(type: "int", nullable: false),
                    KickReturnYards = table.Column<int>(type: "int", nullable: false),
                    PuntReturns = table.Column<int>(type: "int", nullable: false),
                    PuntReturnYards = table.Column<int>(type: "int", nullable: false),
                    Touchdowns = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialTeamsGameStats", x => new { x.GameId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_SpecialTeamsGameStats_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialTeamsGameStats_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DefensiveGameStats_PlayerId",
                table: "DefensiveGameStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_SeasonId",
                table: "Game",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_OffensiveGameStats_PlayerId",
                table: "OffensiveGameStats",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonPlayers_PlayerId",
                table: "SeasonPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SeasonPlayers_SeasonId",
                table: "SeasonPlayers",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialTeamsGameStats_PlayerId",
                table: "SpecialTeamsGameStats",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefensiveGameStats");

            migrationBuilder.DropTable(
                name: "OffensiveGameStats");

            migrationBuilder.DropTable(
                name: "SeasonPlayers");

            migrationBuilder.DropTable(
                name: "SpecialTeamsGameStats");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Season");
        }
    }
}
