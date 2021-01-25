using Microsoft.EntityFrameworkCore.Migrations;

namespace OnboardingSIGDB1.Data.Migrations
{
    public partial class atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "FuncionariosCargos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdEmpresa",
                table: "Funcionarios",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Funcionarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Empresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CascadeMode",
                table: "Cargos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "FuncionariosCargos");

            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "CascadeMode",
                table: "Cargos");

            migrationBuilder.AlterColumn<int>(
                name: "IdEmpresa",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
