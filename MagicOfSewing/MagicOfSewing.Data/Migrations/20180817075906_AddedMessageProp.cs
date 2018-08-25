using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicOfSewing.Data.Migrations
{
    public partial class AddedMessageProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAnswered",
                table: "ContactMessages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswered",
                table: "ContactMessages");
        }
    }
}
