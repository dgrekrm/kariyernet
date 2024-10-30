using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KariyerApp.Core.Migrations
{
    /// <inheritdoc />
    public partial class JobAdvertisementManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compensations_JobAdvertisements_JobAdvertisementId",
                table: "Compensations");

            migrationBuilder.DropIndex(
                name: "IX_Compensations_JobAdvertisementId",
                table: "Compensations");

            migrationBuilder.DropColumn(
                name: "JobAdvertisementId",
                table: "Compensations");

            migrationBuilder.CreateTable(
                name: "CompensationJobAdvertisement",
                columns: table => new
                {
                    CompensationsId = table.Column<int>(type: "integer", nullable: false),
                    JobAdvertisementsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompensationJobAdvertisement", x => new { x.CompensationsId, x.JobAdvertisementsId });
                    table.ForeignKey(
                        name: "FK_CompensationJobAdvertisement_Compensations_CompensationsId",
                        column: x => x.CompensationsId,
                        principalTable: "Compensations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompensationJobAdvertisement_JobAdvertisements_JobAdvertise~",
                        column: x => x.JobAdvertisementsId,
                        principalTable: "JobAdvertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompensationJobAdvertisement_JobAdvertisementsId",
                table: "CompensationJobAdvertisement",
                column: "JobAdvertisementsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompensationJobAdvertisement");

            migrationBuilder.AddColumn<int>(
                name: "JobAdvertisementId",
                table: "Compensations",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compensations_JobAdvertisementId",
                table: "Compensations",
                column: "JobAdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compensations_JobAdvertisements_JobAdvertisementId",
                table: "Compensations",
                column: "JobAdvertisementId",
                principalTable: "JobAdvertisements",
                principalColumn: "Id");
        }
    }
}
