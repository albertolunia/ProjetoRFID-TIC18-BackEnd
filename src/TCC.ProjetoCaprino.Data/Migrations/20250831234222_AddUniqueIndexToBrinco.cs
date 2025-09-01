using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC.ProjetoCaprino.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexToBrinco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Caprino_Brinco",
                table: "Caprino",
                column: "Brinco",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Caprino_Brinco",
                table: "Caprino");
        }
    }
}
