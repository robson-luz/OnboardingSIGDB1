using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnboardingSIGDB1.Data.Migrations
{
    public partial class CriacaoProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(maxLength: 14, nullable: false),
                    DataFundacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    DataContratacao = table.Column<DateTime>(nullable: true),
                    IdEmpresa = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuncionariosCargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdFuncionario = table.Column<int>(nullable: false),
                    IdCargo = table.Column<int>(nullable: false),
                    DataVinculo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionariosCargos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionariosCargos_Cargos_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionariosCargos_Funcionarios_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_IdEmpresa",
                table: "Funcionarios",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosCargos_IdCargo",
                table: "FuncionariosCargos",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionariosCargos_IdFuncionario",
                table: "FuncionariosCargos",
                column: "IdFuncionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuncionariosCargos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
