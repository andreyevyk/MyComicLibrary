using Microsoft.EntityFrameworkCore.Migrations;

namespace MyComicLibrary.Migrations
{
    public partial class RetirarRequiredDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "comic",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "comic",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
