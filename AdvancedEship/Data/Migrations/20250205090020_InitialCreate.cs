using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvancedEship.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
