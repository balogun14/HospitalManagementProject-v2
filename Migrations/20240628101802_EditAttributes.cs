using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalManagementProject.Migrations
{
    /// <inheritdoc />
    public partial class EditAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "Prescriptions",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "Prescriptions",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Appointments",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Appointments");
        }
    }
}
