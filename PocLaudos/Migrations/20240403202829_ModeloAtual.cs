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
                name: "LaudoPericial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Emissao = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: false),
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
                name: "ValorData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Valor = table.Column<DateTime>(type: "timestamp(0) with time zone", precision: 0, nullable: true),
                    LaudoPericialId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    Valor = table.Column<double>(type: "double precision", nullable: true),
                    LaudoPericialId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    Valor = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    LaudoPericialId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassificadorCampoId = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "FK_ValorLista_LaudoPericial_LaudoPericialId",
                        column: x => x.LaudoPericialId,
                        principalTable: "LaudoPericial",
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
                name: "IX_LaudoPericial_ModeloLaudoId",
                table: "LaudoPericial",
                column: "ModeloLaudoId");

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
                name: "IX_ValorLista_LaudoPericialId",
                table: "ValorLista",
                column: "LaudoPericialId");
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
                name: "ValorData");

            migrationBuilder.DropTable(
                name: "ValorDecimal");

            migrationBuilder.DropTable(
                name: "ValorLista");

            migrationBuilder.DropTable(
                name: "Lista");

            migrationBuilder.DropTable(
                name: "LaudoPericial");

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
