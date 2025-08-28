using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC.ProjetoCaprino.Data.Migrations
{
    /// <inheritdoc />
    public partial class quantidadeDeLeiteNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
        name: "QuantidadeDeLeite",
        table: "HistoricoDoCaprino",
        type: "decimal(18,2)",
        nullable: true,
        oldClrType: typeof(decimal),
        oldType: "decimal(18,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
        name: "QuantidadeDeLeite",
        table: "HistoricoDoCaprino",
        type: "decimal(18,2)",
        nullable: false,
        oldClrType: typeof(decimal),
        oldType: "decimal(18,2)",
        oldNullable: true);
        }
    }
}
