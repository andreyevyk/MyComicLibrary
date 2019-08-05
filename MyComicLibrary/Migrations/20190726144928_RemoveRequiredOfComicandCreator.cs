using Microsoft.EntityFrameworkCore.Migrations;

namespace MyComicLibrary.Migrations
{
    public partial class RemoveRequiredOfComicandCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_comic_id_comic",
                table: "characters");

            migrationBuilder.DropForeignKey(
                name: "FK_creator_comic_id_comic",
                table: "creator");

            migrationBuilder.AlterColumn<int>(
                name: "id_comic",
                table: "creator",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "id_comic",
                table: "characters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_characters_comic_id_comic",
                table: "characters",
                column: "id_comic",
                principalTable: "comic",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_creator_comic_id_comic",
                table: "creator",
                column: "id_comic",
                principalTable: "comic",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_comic_id_comic",
                table: "characters");

            migrationBuilder.DropForeignKey(
                name: "FK_creator_comic_id_comic",
                table: "creator");

            migrationBuilder.AlterColumn<int>(
                name: "id_comic",
                table: "creator",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id_comic",
                table: "characters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_characters_comic_id_comic",
                table: "characters",
                column: "id_comic",
                principalTable: "comic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_creator_comic_id_comic",
                table: "creator",
                column: "id_comic",
                principalTable: "comic",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
