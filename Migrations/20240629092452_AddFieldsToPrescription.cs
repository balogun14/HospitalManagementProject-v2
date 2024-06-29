using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsToPrescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Treatment",
                table: "Prescriptions",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Treatment",
                table: "Prescriptions");
        }
    }
}
