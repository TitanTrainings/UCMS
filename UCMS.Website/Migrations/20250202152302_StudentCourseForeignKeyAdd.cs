using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UCMS.Website.Migrations
{
    /// <inheritdoc />
    public partial class StudentCourseForeignKeyAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Faculty",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Faculty");
        }
    }
}
