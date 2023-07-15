using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RR.DataBaseConnect.Migrations
{
    /// <inheritdoc />
    public partial class Migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeadCitation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NominatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampaignsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadCitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadCitation_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OtherRewardResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    NominatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomineeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CampaignsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherRewardResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherRewardResults_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OtherRewardResults_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadCitationReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    NominatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplierId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReplyCitation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeadCitationId = table.Column<int>(type: "int", nullable: true),
                    CampaignsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadCitationReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadCitationReplies_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeadCitationReplies_LeadCitation_LeadCitationId",
                        column: x => x.LeadCitationId,
                        principalTable: "LeadCitation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OtherRewards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    NominatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomineeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    CampaignsId = table.Column<int>(type: "int", nullable: false),
                    LeadCitationId = table.Column<int>(type: "int", nullable: true),
                    OtherRewardResultsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherRewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherRewards_Campaigns_CampaignsId",
                        column: x => x.CampaignsId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OtherRewards_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OtherRewards_LeadCitation_LeadCitationId",
                        column: x => x.LeadCitationId,
                        principalTable: "LeadCitation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OtherRewards_OtherRewardResults_OtherRewardResultsId",
                        column: x => x.OtherRewardResultsId,
                        principalTable: "OtherRewardResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeadCitation_CampaignsId",
                table: "LeadCitation",
                column: "CampaignsId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadCitationReplies_CampaignsId",
                table: "LeadCitationReplies",
                column: "CampaignsId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadCitationReplies_LeadCitationId",
                table: "LeadCitationReplies",
                column: "LeadCitationId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherRewardResults_CampaignsId",
                table: "OtherRewardResults",
                column: "CampaignsId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherRewardResults_EmployeeId",
                table: "OtherRewardResults",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherRewards_CampaignsId",
                table: "OtherRewards",
                column: "CampaignsId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherRewards_EmployeeId",
                table: "OtherRewards",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherRewards_LeadCitationId",
                table: "OtherRewards",
                column: "LeadCitationId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherRewards_OtherRewardResultsId",
                table: "OtherRewards",
                column: "OtherRewardResultsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeadCitationReplies");

            migrationBuilder.DropTable(
                name: "OtherRewards");

            migrationBuilder.DropTable(
                name: "LeadCitation");

            migrationBuilder.DropTable(
                name: "OtherRewardResults");
        }
    }
}
