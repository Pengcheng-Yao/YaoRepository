using Microsoft.EntityFrameworkCore.Migrations;

namespace WordTest.Migrations
{
    public partial class context01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "w_code",
                table: "tb_role",
                maxLength: 10,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "w_code",
                table: "tb_role");
        }
    }
}
