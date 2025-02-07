using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedEship.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserAccounts",
                newName: "My_UserName");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "UserAccounts",
                newName: "My_Role");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "UserAccounts",
                newName: "My_Phone");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "UserAccounts",
                newName: "My_Password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "UserAccounts",
                newName: "My_Note");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "UserAccounts",
                newName: "My_Email");

            migrationBuilder.AddColumn<string>(
                name: "My_Address",
                table: "UserAccounts",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "My_Address",
                table: "UserAccounts");

            migrationBuilder.RenameColumn(
                name: "My_UserName",
                table: "UserAccounts",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "My_Role",
                table: "UserAccounts",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "My_Phone",
                table: "UserAccounts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "My_Password",
                table: "UserAccounts",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "My_Note",
                table: "UserAccounts",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "My_Email",
                table: "UserAccounts",
                newName: "Address");
        }
    }
}
