using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC.ProjetoCaprino.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial_commit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Raca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packaging", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDeEvento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfidTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDeVacina = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeAlimento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDeAlimento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeAlimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeCriacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDeCriacao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeCriacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caprino",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brinco = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PesoAtual = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sexo = table.Column<bool>(type: "bit", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RacaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDeCricaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caprino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caprino_Packaging_RacaId",
                        column: x => x.RacaId,
                        principalTable: "Raca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Caprino_TipoDeCriacao_TipoDeCricaoId",
                        column: x => x.TipoDeCricaoId,
                        principalTable: "TipoDeCriacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoDoCaprino",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaprinoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeDeLeite = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoDeAlimentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeDeAlimento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EventoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VacinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDoCaprino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoDoCaprino_Caprino_CaprinoId",
                        column: x => x.CaprinoId,
                        principalTable: "Caprino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoDoCaprino_RfidTag_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoDoCaprino_Supplier_VacinaId",
                        column: x => x.VacinaId,
                        principalTable: "Vacina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoDoCaprino_TipoDeAlimento_TipoDeAlimentoId",
                        column: x => x.TipoDeAlimentoId,
                        principalTable: "TipoDeAlimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caprino_RacaId",
                table: "Caprino",
                column: "RacaId");

            migrationBuilder.CreateIndex(
                name: "IX_Caprino_TipoDeCricaoId",
                table: "Caprino",
                column: "TipoDeCricaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDoCaprino_CaprinoId",
                table: "HistoricoDoCaprino",
                column: "CaprinoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDoCaprino_EventoId",
                table: "HistoricoDoCaprino",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDoCaprino_TipoDeAlimentoId",
                table: "HistoricoDoCaprino",
                column: "TipoDeAlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoDoCaprino_VacinaId",
                table: "HistoricoDoCaprino",
                column: "VacinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoDoCaprino");

            migrationBuilder.DropTable(
                name: "Caprino");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Vacina");

            migrationBuilder.DropTable(
                name: "TipoDeAlimento");

            migrationBuilder.DropTable(
                name: "Raca");

            migrationBuilder.DropTable(
                name: "TipoDeCriacao");
        }
    }
}
