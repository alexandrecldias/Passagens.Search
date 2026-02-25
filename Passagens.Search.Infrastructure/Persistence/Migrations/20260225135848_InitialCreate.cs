using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Passagens.Search.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pesquisas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AeroportoOrigem = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    AeroportoDestino = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    DataIda = table.Column<DateOnly>(type: "date", nullable: false),
                    DataVolta = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pesquisas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pesquisa_snapshots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PesquisaId = table.Column<Guid>(type: "uuid", nullable: false),
                    PesquisadoEmUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RawJson = table.Column<string>(type: "jsonb", nullable: true),
                    ResultHash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pesquisa_snapshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pesquisa_snapshots_pesquisas_PesquisaId",
                        column: x => x.PesquisaId,
                        principalTable: "pesquisas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "voos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SnapshotId = table.Column<Guid>(type: "uuid", nullable: false),
                    Companhia = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    NumeroVoo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    DuracaoMinutos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_voos_pesquisa_snapshots_SnapshotId",
                        column: x => x.SnapshotId,
                        principalTable: "pesquisa_snapshots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pesquisa_snapshots_PesquisaId",
                table: "pesquisa_snapshots",
                column: "PesquisaId");

            migrationBuilder.CreateIndex(
                name: "IX_voos_SnapshotId",
                table: "voos",
                column: "SnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_voos_Valor",
                table: "voos",
                column: "Valor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "voos");

            migrationBuilder.DropTable(
                name: "pesquisa_snapshots");

            migrationBuilder.DropTable(
                name: "pesquisas");
        }
    }
}
