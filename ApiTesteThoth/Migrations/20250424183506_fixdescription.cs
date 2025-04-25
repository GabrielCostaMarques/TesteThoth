using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiTesteThoth.Migrations
{
    /// <inheritdoc />
    public partial class fixdescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descrição",
                table: "Compromissos",
                newName: "Descricao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Compromissos",
                newName: "Descrição");
        }
    }
}
