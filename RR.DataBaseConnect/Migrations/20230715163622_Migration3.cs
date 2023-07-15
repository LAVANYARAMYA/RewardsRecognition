using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RR.DataBaseConnect.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeerToPeerResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomineeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NominatorId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Citation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeerToPeerResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeerToPeerResults_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PeerToPeer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NominatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: true),
                    Citation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomineeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CampaignsId = table.Column<int>(type: "int", nullable: true),
                    PeerToPeerResultsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeerToPeer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeerToPeer_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeerToPeer_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PeerToPeer_PeerToPeerResults_PeerToPeerResultsId",
                        column: x => x.PeerToPeerResultsId,
                        principalTable: "PeerToPeerResults",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeerToPeer_CampaignsId",
                table: "PeerToPeer",
                column: "CampaignsId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerToPeer_EmployeeId",
                table: "PeerToPeer",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerToPeer_PeerToPeerResultsId",
                table: "PeerToPeer",
                column: "PeerToPeerResultsId");

            migrationBuilder.CreateIndex(
                name: "IX_PeerToPeerResults_EmployeeId",
                table: "PeerToPeerResults",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeerToPeer");

            migrationBuilder.DropTable(
                name: "PeerToPeerResults");
        }
    }
}
