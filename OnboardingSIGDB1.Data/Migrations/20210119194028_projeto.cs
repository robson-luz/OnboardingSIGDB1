using Microsoft.EntityFrameworkCore.Migrations;

namespace OnboardingSIGDB1.Data.Migrations
{
    public partial class projeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Empresas",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Empresas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }
    }
}
