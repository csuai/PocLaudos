using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocLaudos.Migrations
{
    /// <inheritdoc />
    public partial class LaudoPericial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaudoPericial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    ModeloLaudoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaudoPericial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaudoPericial_ModeloLaudo_ModeloLaudoId",
                        column: x => x.ModeloLaudoId,
                        principalTable: "ModeloLaudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValorData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LaudoPericialId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Valor = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValorData_ClassificadorCampo_ClassificadorCampoId",
                        column: x => x.ClassificadorCampoId,
                        principalTable: "ClassificadorCampo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValorData_LaudoPericial_LaudoPericialId",
                        column: x => x.LaudoPericialId,
                        principalTable: "LaudoPericial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValorDecimal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LaudoPericialId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorDecimal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValorDecimal_ClassificadorCampo_ClassificadorCampoId",
                        column: x => x.ClassificadorCampoId,
                        principalTable: "ClassificadorCampo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValorDecimal_LaudoPericial_LaudoPericialId",
                        column: x => x.LaudoPericialId,
                        principalTable: "LaudoPericial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValorLista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LaudoPericialId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemListaId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorLista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValorLista_ClassificadorCampo_ClassificadorCampoId",
                        column: x => x.ClassificadorCampoId,
                        principalTable: "ClassificadorCampo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValorLista_ItemLista_ItemListaId",
                        column: x => x.ItemListaId,
                        principalTable: "ItemLista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValorLista_LaudoPericial_LaudoPericialId",
                        column: x => x.LaudoPericialId,
                        principalTable: "LaudoPericial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaudoPericial_ModeloLaudoId",
                table: "LaudoPericial",
                column: "ModeloLaudoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorData_ClassificadorCampoId",
                table: "ValorData",
                column: "ClassificadorCampoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorData_LaudoPericialId",
                table: "ValorData",
                column: "LaudoPericialId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorDecimal_ClassificadorCampoId",
                table: "ValorDecimal",
                column: "ClassificadorCampoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorDecimal_LaudoPericialId",
                table: "ValorDecimal",
                column: "LaudoPericialId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorLista_ClassificadorCampoId",
                table: "ValorLista",
                column: "ClassificadorCampoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorLista_ItemListaId",
                table: "ValorLista",
                column: "ItemListaId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorLista_LaudoPericialId",
                table: "ValorLista",
                column: "LaudoPericialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValorData");

            migrationBuilder.DropTable(
                name: "ValorDecimal");

            migrationBuilder.DropTable(
                name: "ValorLista");

            migrationBuilder.DropTable(
                name: "LaudoPericial");
        }
    }
}
