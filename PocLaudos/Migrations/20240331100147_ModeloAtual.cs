using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocLaudos.Migrations
{
    /// <inheritdoc />
    public partial class ModeloAtual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Fav = table.Column<bool>(type: "boolean", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoClassificadorCampo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoClassificadorCampo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModeloLaudo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EspecieId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeloLaudo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeloLaudo_Especie_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassificadorCampo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificadorCampo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassificadorCampo_TipoClassificadorCampo_TipoClassificador~",
                        column: x => x.TipoClassificadorCampoId,
                        principalTable: "TipoClassificadorCampo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Texto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Texto = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ModeloLaudoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Texto_ModeloLaudo_ModeloLaudoId",
                        column: x => x.ModeloLaudoId,
                        principalTable: "ModeloLaudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CampoDecimal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModeloLaudoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampoDecimal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampoDecimal_ClassificadorCampo_ClassificadorCampoId",
                        column: x => x.ClassificadorCampoId,
                        principalTable: "ClassificadorCampo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampoDecimal_ModeloLaudo_ModeloLaudoId",
                        column: x => x.ModeloLaudoId,
                        principalTable: "ModeloLaudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ModeloLaudoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Data_ClassificadorCampo_ClassificadorCampoId",
                        column: x => x.ClassificadorCampoId,
                        principalTable: "ClassificadorCampo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Data_ModeloLaudo_ModeloLaudoId",
                        column: x => x.ModeloLaudoId,
                        principalTable: "ModeloLaudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MultiplosValores = table.Column<bool>(type: "boolean", nullable: false),
                    ModeloLaudoId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lista_ClassificadorCampo_ClassificadorCampoId",
                        column: x => x.ClassificadorCampoId,
                        principalTable: "ClassificadorCampo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lista_ModeloLaudo_ModeloLaudoId",
                        column: x => x.ModeloLaudoId,
                        principalTable: "ModeloLaudo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemLista",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CampoListaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemLista_Lista_CampoListaId",
                        column: x => x.CampoListaId,
                        principalTable: "Lista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampoDecimal_ClassificadorCampoId",
                table: "CampoDecimal",
                column: "ClassificadorCampoId");

            migrationBuilder.CreateIndex(
                name: "IX_CampoDecimal_ModeloLaudoId",
                table: "CampoDecimal",
                column: "ModeloLaudoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificadorCampo_TipoClassificadorCampoId",
                table: "ClassificadorCampo",
                column: "TipoClassificadorCampoId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_ClassificadorCampoId",
                table: "Data",
                column: "ClassificadorCampoId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_ModeloLaudoId",
                table: "Data",
                column: "ModeloLaudoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemLista_CampoListaId",
                table: "ItemLista",
                column: "CampoListaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_ClassificadorCampoId",
                table: "Lista",
                column: "ClassificadorCampoId");

            migrationBuilder.CreateIndex(
                name: "IX_Lista_ModeloLaudoId",
                table: "Lista",
                column: "ModeloLaudoId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeloLaudo_EspecieId",
                table: "ModeloLaudo",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Texto_ModeloLaudoId",
                table: "Texto",
                column: "ModeloLaudoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampoDecimal");

            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "ItemLista");

            migrationBuilder.DropTable(
                name: "Texto");

            migrationBuilder.DropTable(
                name: "Lista");

            migrationBuilder.DropTable(
                name: "ClassificadorCampo");

            migrationBuilder.DropTable(
                name: "ModeloLaudo");

            migrationBuilder.DropTable(
                name: "TipoClassificadorCampo");

            migrationBuilder.DropTable(
                name: "Especie");
        }
    }
}
