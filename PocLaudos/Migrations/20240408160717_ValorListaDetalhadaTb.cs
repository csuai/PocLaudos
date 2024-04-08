using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocLaudos.Migrations
{
    /// <inheritdoc />
    public partial class ValorListaDetalhadaTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CampoListaDetalhadaId",
                table: "ItemLista",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CampoListaDetalhada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MultiplosValores = table.Column<bool>(type: "boolean", nullable: false),
                    ModeloLaudoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampoListaDetalhada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampoListaDetalhada_ClassificadorCampo_ClassificadorCampoId",
                        column: x => x.ClassificadorCampoId,
                        principalTable: "ClassificadorCampo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampoListaDetalhada_ModeloLaudo_ModeloLaudoId",
                        column: x => x.ModeloLaudoId,
                        principalTable: "ModeloLaudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ValorListaDetalhada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Valor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Detalhamento = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LaudoPericialId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValorListaDetalhada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ValorListaDetalhada_ClassificadorCampo_ClassificadorCampoId",
                        column: x => x.ClassificadorCampoId,
                        principalTable: "ClassificadorCampo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ValorListaDetalhada_LaudoPericial_LaudoPericialId",
                        column: x => x.LaudoPericialId,
                        principalTable: "LaudoPericial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemLista_CampoListaDetalhadaId",
                table: "ItemLista",
                column: "CampoListaDetalhadaId");

            migrationBuilder.CreateIndex(
                name: "IX_CampoListaDetalhada_ClassificadorCampoId",
                table: "CampoListaDetalhada",
                column: "ClassificadorCampoId");

            migrationBuilder.CreateIndex(
                name: "IX_CampoListaDetalhada_ModeloLaudoId",
                table: "CampoListaDetalhada",
                column: "ModeloLaudoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorListaDetalhada_ClassificadorCampoId",
                table: "ValorListaDetalhada",
                column: "ClassificadorCampoId");

            migrationBuilder.CreateIndex(
                name: "IX_ValorListaDetalhada_LaudoPericialId",
                table: "ValorListaDetalhada",
                column: "LaudoPericialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemLista_CampoListaDetalhada_CampoListaDetalhadaId",
                table: "ItemLista",
                column: "CampoListaDetalhadaId",
                principalTable: "CampoListaDetalhada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemLista_CampoListaDetalhada_CampoListaDetalhadaId",
                table: "ItemLista");

            migrationBuilder.DropTable(
                name: "CampoListaDetalhada");

            migrationBuilder.DropTable(
                name: "ValorListaDetalhada");

            migrationBuilder.DropIndex(
                name: "IX_ItemLista_CampoListaDetalhadaId",
                table: "ItemLista");

            migrationBuilder.DropColumn(
                name: "CampoListaDetalhadaId",
                table: "ItemLista");
        }
    }
}
