using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicOfSewing.Data.Migrations
{
    public partial class AddedSomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Articles_ArticleId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Videos_VideoId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "VideoId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Articles_ArticleId",
                table: "Posts",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Videos_VideoId",
                table: "Posts",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Articles_ArticleId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Videos_VideoId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "VideoId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Articles_ArticleId",
                table: "Posts",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Videos_VideoId",
                table: "Posts",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
