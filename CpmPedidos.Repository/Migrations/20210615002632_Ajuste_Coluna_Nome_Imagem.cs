using Microsoft.EntityFrameworkCore.Migrations;

namespace CpmPedidos.Repository.Migrations
{
    public partial class Ajuste_Coluna_Nome_Imagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome_do_arquivo",
                table: "tb_imagem",
                newName: "nome_arquivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nome_arquivo",
                table: "tb_imagem",
                newName: "nome_do_arquivo");
        }
    }
}
