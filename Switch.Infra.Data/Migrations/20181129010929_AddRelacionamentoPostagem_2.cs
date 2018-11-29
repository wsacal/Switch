using Microsoft.EntityFrameworkCore.Migrations;

namespace Switch.Infra.Data.Migrations
{
    public partial class AddRelacionamentoPostagem_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identificacao_Usuarios_UsuarioID",
                table: "Identificacao");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Identificacao",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Identificacao_UsuarioID",
                table: "Identificacao",
                newName: "IX_Identificacao_UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identificacao_Usuarios_UsuarioId",
                table: "Identificacao",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identificacao_Usuarios_UsuarioId",
                table: "Identificacao");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Identificacao",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Identificacao_UsuarioId",
                table: "Identificacao",
                newName: "IX_Identificacao_UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Identificacao_Usuarios_UsuarioID",
                table: "Identificacao",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
