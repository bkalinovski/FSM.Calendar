using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FSM.Calendar.Persistance.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProcessAliases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessAliases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    FromTime = table.Column<TimeSpan>(type: "time(7)", nullable: false),
                    ToTime = table.Column<TimeSpan>(type: "time(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerritoryAliases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryAliases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ExternalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessAliasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processes_ProcessAliases_ProcessAliasId",
                        column: x => x.ProcessAliasId,
                        principalTable: "ProcessAliases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SlotAssignments",
                columns: table => new
                {
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    ProcessAliasId = table.Column<int>(type: "int", nullable: false),
                    TerritoryAliasId = table.Column<int>(type: "int", nullable: false),
                    TotalCases = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotAssignments", x => new { x.SlotId, x.TerritoryAliasId, x.ProcessAliasId });
                    table.ForeignKey(
                        name: "FK_SlotAssignments_ProcessAliases_ProcessAliasId",
                        column: x => x.ProcessAliasId,
                        principalTable: "ProcessAliases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlotAssignments_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlotAssignments_TerritoryAliases_TerritoryAliasId",
                        column: x => x.TerritoryAliasId,
                        principalTable: "TerritoryAliases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    ExternalId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Territories_TerritoryAliases_RegionId",
                        column: x => x.RegionId,
                        principalTable: "TerritoryAliases",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeamAssignments",
                columns: table => new
                {
                    SlotId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    TerritoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamAssignments", x => new { x.SlotId, x.TeamId, x.ProcessId, x.TerritoryId });
                    table.ForeignKey(
                        name: "FK_TeamAssignments_Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamAssignments_Slots_SlotId",
                        column: x => x.SlotId,
                        principalTable: "Slots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamAssignments_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamAssignments_Territories_TerritoryId",
                        column: x => x.TerritoryId,
                        principalTable: "Territories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processes_ProcessAliasId",
                table: "Processes",
                column: "ProcessAliasId");

            migrationBuilder.CreateIndex(
                name: "IX_SlotAssignments_ProcessAliasId",
                table: "SlotAssignments",
                column: "ProcessAliasId");

            migrationBuilder.CreateIndex(
                name: "IX_SlotAssignments_TerritoryAliasId",
                table: "SlotAssignments",
                column: "TerritoryAliasId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamAssignments_ProcessId",
                table: "TeamAssignments",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamAssignments_TeamId",
                table: "TeamAssignments",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamAssignments_TerritoryId",
                table: "TeamAssignments",
                column: "TerritoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Territories_RegionId",
                table: "Territories",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlotAssignments");

            migrationBuilder.DropTable(
                name: "TeamAssignments");

            migrationBuilder.DropTable(
                name: "Processes");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "ProcessAliases");

            migrationBuilder.DropTable(
                name: "TerritoryAliases");
        }
    }
}
