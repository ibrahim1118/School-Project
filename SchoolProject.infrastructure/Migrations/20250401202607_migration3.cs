using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_instructors_SuperVisorId",
                table: "instructors");

            migrationBuilder.AlterColumn<int>(
                name: "SuperVisorId",
                table: "instructors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_instructors_SuperVisorId",
                table: "instructors",
                column: "SuperVisorId",
                principalTable: "instructors",
                principalColumn: "InsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_instructors_instructors_SuperVisorId",
                table: "instructors");

            migrationBuilder.AlterColumn<int>(
                name: "SuperVisorId",
                table: "instructors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_instructors_instructors_SuperVisorId",
                table: "instructors",
                column: "SuperVisorId",
                principalTable: "instructors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
