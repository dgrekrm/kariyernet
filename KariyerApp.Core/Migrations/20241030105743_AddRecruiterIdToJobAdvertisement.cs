using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KariyerApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddRecruiterIdToJobAdvertisement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecruiterId",
                table: "JobAdvertisements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobAdvertisements_RecruiterId",
                table: "JobAdvertisements",
                column: "RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobAdvertisements_Recruiters_RecruiterId",
                table: "JobAdvertisements",
                column: "RecruiterId",
                principalTable: "Recruiters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobAdvertisements_Recruiters_RecruiterId",
                table: "JobAdvertisements");

            migrationBuilder.DropIndex(
                name: "IX_JobAdvertisements_RecruiterId",
                table: "JobAdvertisements");

            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "JobAdvertisements");
        }
    }
}
