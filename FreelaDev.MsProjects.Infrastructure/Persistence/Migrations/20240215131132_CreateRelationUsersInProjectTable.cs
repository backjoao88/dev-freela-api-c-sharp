using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelaDev.MsProjects.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationUsersInProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "tbl_Project",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishedAt",
                table: "tbl_Project",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Project_IdClient",
                table: "tbl_Project",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Project_IdFreelancer",
                table: "tbl_Project",
                column: "IdFreelancer");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Project_tbl_User_IdClient",
                table: "tbl_Project",
                column: "IdClient",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Project_tbl_User_IdFreelancer",
                table: "tbl_Project",
                column: "IdFreelancer",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Project_tbl_User_IdClient",
                table: "tbl_Project");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Project_tbl_User_IdFreelancer",
                table: "tbl_Project");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Project_IdClient",
                table: "tbl_Project");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Project_IdFreelancer",
                table: "tbl_Project");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartedAt",
                table: "tbl_Project",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishedAt",
                table: "tbl_Project",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);
        }
    }
}
