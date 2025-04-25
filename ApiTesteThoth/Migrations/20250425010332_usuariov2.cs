using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTesteThoth.Migrations
{
    /// <inheritdoc />
    public partial class usuariov2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compromissos_Usuarios_UsuarioId",
                table: "Compromissos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Compromissos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compromissos_Usuarios_UsuarioId",
                table: "Compromissos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compromissos_Usuarios_UsuarioId",
                table: "Compromissos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Compromissos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Compromissos_Usuarios_UsuarioId",
                table: "Compromissos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
