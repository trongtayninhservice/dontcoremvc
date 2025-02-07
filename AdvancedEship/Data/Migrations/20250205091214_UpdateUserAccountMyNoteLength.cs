using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedEship.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserAccountMyNoteLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "My_Note",
                table: "UserAccounts",
                type: "nvarchar(max)",
                maxLength: 5350,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "My_Note",
                table: "UserAccounts",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5350,
                oldNullable: true);
        }
    }
}
