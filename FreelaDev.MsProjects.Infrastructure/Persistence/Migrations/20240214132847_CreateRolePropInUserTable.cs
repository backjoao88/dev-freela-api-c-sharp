using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FreelaDev.MsProjects.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateRolePropInUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "tbl_User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "tbl_User");
        }
    }
}
