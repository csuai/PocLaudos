/*
 Navicat Premium Data Transfer

 Source Server         : localhost_5432
 Source Server Type    : PostgreSQL
 Source Server Version : 160002 (160002)
 Source Host           : localhost:5432
 Source Catalog        : PcoLaudos
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 160002 (160002)
 File Encoding         : 65001

 Date: 02/04/2024 16:14:15
*/


-- ----------------------------
-- Table structure for CampoDecimal
-- ----------------------------
DROP TABLE IF EXISTS "public"."CampoDecimal";
CREATE TABLE "public"."CampoDecimal" (
  "Id" uuid NOT NULL,
  "ModeloLaudoId" uuid NOT NULL,
  "ClassificadorCampoId" uuid NOT NULL
)
;

-- ----------------------------
-- Records of CampoDecimal
-- ----------------------------

-- ----------------------------
-- Table structure for ClassificadorCampo
-- ----------------------------
DROP TABLE IF EXISTS "public"."ClassificadorCampo";
CREATE TABLE "public"."ClassificadorCampo" (
  "Id" uuid NOT NULL,
  "TipoClassificadorCampoId" uuid NOT NULL,
  "Nome" varchar(255) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of ClassificadorCampo
-- ----------------------------
INSERT INTO "public"."ClassificadorCampo" VALUES ('2249f144-4cdc-4232-8898-d6928d6ef537', '20dc207c-b5ce-4ee1-ad5a-33d5c9e7a207', 'Calibre');
INSERT INTO "public"."ClassificadorCampo" VALUES ('6da0f0a5-36de-4b36-a6dc-6cbfabaa7ad1', '83619b3a-ad84-4eef-94e7-a5ecedd9eea7', 'Massa de Maconha');
INSERT INTO "public"."ClassificadorCampo" VALUES ('93eb6514-3683-4dbb-8f18-f8ee7f6e900a', '83619b3a-ad84-4eef-94e7-a5ecedd9eea7', 'Massa de Cocaína');
INSERT INTO "public"."ClassificadorCampo" VALUES ('ad6e91c6-e131-4228-a91a-f7d1957c861f', '20dc207c-b5ce-4ee1-ad5a-33d5c9e7a207', 'Substância TX');
INSERT INTO "public"."ClassificadorCampo" VALUES ('e0f88bdc-1a35-4db9-b8da-931fabad6bd7', 'feafe3ec-6084-432f-b992-52f29d284e24', 'Morte');

-- ----------------------------
-- Table structure for Data
-- ----------------------------
DROP TABLE IF EXISTS "public"."Data";
CREATE TABLE "public"."Data" (
  "Id" uuid NOT NULL,
  "ModeloLaudoId" uuid NOT NULL,
  "ClassificadorCampoId" uuid NOT NULL
)
;

-- ----------------------------
-- Records of Data
-- ----------------------------

-- ----------------------------
-- Table structure for Especie
-- ----------------------------
DROP TABLE IF EXISTS "public"."Especie";
CREATE TABLE "public"."Especie" (
  "Id" uuid NOT NULL,
  "Fav" bool NOT NULL,
  "Nome" varchar(255) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of Especie
-- ----------------------------
INSERT INTO "public"."Especie" VALUES ('2249f144-4cdc-4232-8898-d6928d6ef537', 't', 'Constatação de Droga de Abuso');
INSERT INTO "public"."Especie" VALUES ('6da0f0a5-36de-4b36-a6dc-6cbfabaa7ad1', 't', 'Exame Definitivo de Droga');
INSERT INTO "public"."Especie" VALUES ('93eb6514-3683-4dbb-8f18-f8ee7f6e900a', 't', 'Eficiência de Arma de Fogo');
INSERT INTO "public"."Especie" VALUES ('ad6e91c6-e131-4228-a91a-f7d1957c861f', 't', 'Determinação de Calibre');
INSERT INTO "public"."Especie" VALUES ('e0f88bdc-1a35-4db9-b8da-931fabad6bd7', 'f', 'Necropsia');

-- ----------------------------
-- Table structure for ItemLista
-- ----------------------------
DROP TABLE IF EXISTS "public"."ItemLista";
CREATE TABLE "public"."ItemLista" (
  "Id" uuid NOT NULL,
  "CampoListaId" uuid NOT NULL,
  "Nome" varchar(255) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of ItemLista
-- ----------------------------

-- ----------------------------
-- Table structure for LaudoPericial
-- ----------------------------
DROP TABLE IF EXISTS "public"."LaudoPericial";
CREATE TABLE "public"."LaudoPericial" (
  "Id" uuid NOT NULL,
  "Numero" int4 NOT NULL,
  "ModeloLaudoId" uuid NOT NULL
)
;

-- ----------------------------
-- Records of LaudoPericial
-- ----------------------------

-- ----------------------------
-- Table structure for Lista
-- ----------------------------
DROP TABLE IF EXISTS "public"."Lista";
CREATE TABLE "public"."Lista" (
  "Id" uuid NOT NULL,
  "MultiplosValores" bool NOT NULL,
  "ModeloLaudoId" uuid NOT NULL,
  "ClassificadorCampoId" uuid NOT NULL
)
;

-- ----------------------------
-- Records of Lista
-- ----------------------------

-- ----------------------------
-- Table structure for ModeloLaudo
-- ----------------------------
DROP TABLE IF EXISTS "public"."ModeloLaudo";
CREATE TABLE "public"."ModeloLaudo" (
  "Id" uuid NOT NULL,
  "EspecieId" uuid NOT NULL,
  "Nome" varchar(255) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of ModeloLaudo
-- ----------------------------

-- ----------------------------
-- Table structure for Texto
-- ----------------------------
DROP TABLE IF EXISTS "public"."Texto";
CREATE TABLE "public"."Texto" (
  "Id" uuid NOT NULL,
  "Titulo" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "Texto" varchar(255) COLLATE "pg_catalog"."default" NOT NULL,
  "ModeloLaudoId" uuid NOT NULL
)
;

-- ----------------------------
-- Records of Texto
-- ----------------------------

-- ----------------------------
-- Table structure for TipoClassificadorCampo
-- ----------------------------
DROP TABLE IF EXISTS "public"."TipoClassificadorCampo";
CREATE TABLE "public"."TipoClassificadorCampo" (
  "Id" uuid NOT NULL,
  "Nome" varchar(255) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of TipoClassificadorCampo
-- ----------------------------
INSERT INTO "public"."TipoClassificadorCampo" VALUES ('20dc207c-b5ce-4ee1-ad5a-33d5c9e7a207', 'Lista');
INSERT INTO "public"."TipoClassificadorCampo" VALUES ('83619b3a-ad84-4eef-94e7-a5ecedd9eea7', 'Decimal');
INSERT INTO "public"."TipoClassificadorCampo" VALUES ('feafe3ec-6084-432f-b992-52f29d284e24', 'Data');

-- ----------------------------
-- Table structure for ValorData
-- ----------------------------
DROP TABLE IF EXISTS "public"."ValorData";
CREATE TABLE "public"."ValorData" (
  "Id" uuid NOT NULL,
  "LaudoPericialId" uuid NOT NULL,
  "ClassificadorCampoId" uuid NOT NULL,
  "Valor" timestamptz(0)
)
;

-- ----------------------------
-- Records of ValorData
-- ----------------------------

-- ----------------------------
-- Table structure for ValorDecimal
-- ----------------------------
DROP TABLE IF EXISTS "public"."ValorDecimal";
CREATE TABLE "public"."ValorDecimal" (
  "Id" uuid NOT NULL,
  "LaudoPericialId" uuid NOT NULL,
  "ClassificadorCampoId" uuid NOT NULL,
  "Valor" float8
)
;

-- ----------------------------
-- Records of ValorDecimal
-- ----------------------------

-- ----------------------------
-- Table structure for ValorLista
-- ----------------------------
DROP TABLE IF EXISTS "public"."ValorLista";
CREATE TABLE "public"."ValorLista" (
  "Id" uuid NOT NULL,
  "LaudoPericialId" uuid NOT NULL,
  "ClassificadorCampoId" uuid NOT NULL,
  "ItemListaId" uuid NOT NULL
)
;

-- ----------------------------
-- Records of ValorLista
-- ----------------------------

-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
DROP TABLE IF EXISTS "public"."__EFMigrationsHistory";
CREATE TABLE "public"."__EFMigrationsHistory" (
  "MigrationId" varchar(150) COLLATE "pg_catalog"."default" NOT NULL,
  "ProductVersion" varchar(32) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20240331100147_ModeloAtual', '8.0.3');
INSERT INTO "public"."__EFMigrationsHistory" VALUES ('20240331102828_LaudoPericial', '8.0.3');

-- ----------------------------
-- Indexes structure for table CampoDecimal
-- ----------------------------
CREATE INDEX "IX_CampoDecimal_ClassificadorCampoId" ON "public"."CampoDecimal" USING btree (
  "ClassificadorCampoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);
CREATE INDEX "IX_CampoDecimal_ModeloLaudoId" ON "public"."CampoDecimal" USING btree (
  "ModeloLaudoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table CampoDecimal
-- ----------------------------
ALTER TABLE "public"."CampoDecimal" ADD CONSTRAINT "PK_CampoDecimal" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ClassificadorCampo
-- ----------------------------
CREATE INDEX "IX_ClassificadorCampo_TipoClassificadorCampoId" ON "public"."ClassificadorCampo" USING btree (
  "TipoClassificadorCampoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ClassificadorCampo
-- ----------------------------
ALTER TABLE "public"."ClassificadorCampo" ADD CONSTRAINT "PK_ClassificadorCampo" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table Data
-- ----------------------------
CREATE INDEX "IX_Data_ClassificadorCampoId" ON "public"."Data" USING btree (
  "ClassificadorCampoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);
CREATE INDEX "IX_Data_ModeloLaudoId" ON "public"."Data" USING btree (
  "ModeloLaudoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table Data
-- ----------------------------
ALTER TABLE "public"."Data" ADD CONSTRAINT "PK_Data" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table Especie
-- ----------------------------
ALTER TABLE "public"."Especie" ADD CONSTRAINT "PK_Especie" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ItemLista
-- ----------------------------
CREATE INDEX "IX_ItemLista_CampoListaId" ON "public"."ItemLista" USING btree (
  "CampoListaId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ItemLista
-- ----------------------------
ALTER TABLE "public"."ItemLista" ADD CONSTRAINT "PK_ItemLista" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table LaudoPericial
-- ----------------------------
CREATE INDEX "IX_LaudoPericial_ModeloLaudoId" ON "public"."LaudoPericial" USING btree (
  "ModeloLaudoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table LaudoPericial
-- ----------------------------
ALTER TABLE "public"."LaudoPericial" ADD CONSTRAINT "PK_LaudoPericial" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table Lista
-- ----------------------------
CREATE INDEX "IX_Lista_ClassificadorCampoId" ON "public"."Lista" USING btree (
  "ClassificadorCampoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);
CREATE INDEX "IX_Lista_ModeloLaudoId" ON "public"."Lista" USING btree (
  "ModeloLaudoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table Lista
-- ----------------------------
ALTER TABLE "public"."Lista" ADD CONSTRAINT "PK_Lista" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ModeloLaudo
-- ----------------------------
CREATE INDEX "IX_ModeloLaudo_EspecieId" ON "public"."ModeloLaudo" USING btree (
  "EspecieId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ModeloLaudo
-- ----------------------------
ALTER TABLE "public"."ModeloLaudo" ADD CONSTRAINT "PK_ModeloLaudo" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table Texto
-- ----------------------------
CREATE INDEX "IX_Texto_ModeloLaudoId" ON "public"."Texto" USING btree (
  "ModeloLaudoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table Texto
-- ----------------------------
ALTER TABLE "public"."Texto" ADD CONSTRAINT "PK_Texto" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table TipoClassificadorCampo
-- ----------------------------
ALTER TABLE "public"."TipoClassificadorCampo" ADD CONSTRAINT "PK_TipoClassificadorCampo" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ValorData
-- ----------------------------
CREATE INDEX "IX_ValorData_ClassificadorCampoId" ON "public"."ValorData" USING btree (
  "ClassificadorCampoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);
CREATE INDEX "IX_ValorData_LaudoPericialId" ON "public"."ValorData" USING btree (
  "LaudoPericialId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ValorData
-- ----------------------------
ALTER TABLE "public"."ValorData" ADD CONSTRAINT "PK_ValorData" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ValorDecimal
-- ----------------------------
CREATE INDEX "IX_ValorDecimal_ClassificadorCampoId" ON "public"."ValorDecimal" USING btree (
  "ClassificadorCampoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);
CREATE INDEX "IX_ValorDecimal_LaudoPericialId" ON "public"."ValorDecimal" USING btree (
  "LaudoPericialId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ValorDecimal
-- ----------------------------
ALTER TABLE "public"."ValorDecimal" ADD CONSTRAINT "PK_ValorDecimal" PRIMARY KEY ("Id");

-- ----------------------------
-- Indexes structure for table ValorLista
-- ----------------------------
CREATE INDEX "IX_ValorLista_ClassificadorCampoId" ON "public"."ValorLista" USING btree (
  "ClassificadorCampoId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);
CREATE INDEX "IX_ValorLista_ItemListaId" ON "public"."ValorLista" USING btree (
  "ItemListaId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);
CREATE INDEX "IX_ValorLista_LaudoPericialId" ON "public"."ValorLista" USING btree (
  "LaudoPericialId" "pg_catalog"."uuid_ops" ASC NULLS LAST
);

-- ----------------------------
-- Primary Key structure for table ValorLista
-- ----------------------------
ALTER TABLE "public"."ValorLista" ADD CONSTRAINT "PK_ValorLista" PRIMARY KEY ("Id");

-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE "public"."__EFMigrationsHistory" ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");

-- ----------------------------
-- Foreign Keys structure for table CampoDecimal
-- ----------------------------
ALTER TABLE "public"."CampoDecimal" ADD CONSTRAINT "FK_CampoDecimal_ClassificadorCampo_ClassificadorCampoId" FOREIGN KEY ("ClassificadorCampoId") REFERENCES "public"."ClassificadorCampo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;
ALTER TABLE "public"."CampoDecimal" ADD CONSTRAINT "FK_CampoDecimal_ModeloLaudo_ModeloLaudoId" FOREIGN KEY ("ModeloLaudoId") REFERENCES "public"."ModeloLaudo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ClassificadorCampo
-- ----------------------------
ALTER TABLE "public"."ClassificadorCampo" ADD CONSTRAINT "FK_ClassificadorCampo_TipoClassificadorCampo_TipoClassificador~" FOREIGN KEY ("TipoClassificadorCampoId") REFERENCES "public"."TipoClassificadorCampo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Data
-- ----------------------------
ALTER TABLE "public"."Data" ADD CONSTRAINT "FK_Data_ClassificadorCampo_ClassificadorCampoId" FOREIGN KEY ("ClassificadorCampoId") REFERENCES "public"."ClassificadorCampo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;
ALTER TABLE "public"."Data" ADD CONSTRAINT "FK_Data_ModeloLaudo_ModeloLaudoId" FOREIGN KEY ("ModeloLaudoId") REFERENCES "public"."ModeloLaudo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ItemLista
-- ----------------------------
ALTER TABLE "public"."ItemLista" ADD CONSTRAINT "FK_ItemLista_Lista_CampoListaId" FOREIGN KEY ("CampoListaId") REFERENCES "public"."Lista" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table LaudoPericial
-- ----------------------------
ALTER TABLE "public"."LaudoPericial" ADD CONSTRAINT "FK_LaudoPericial_ModeloLaudo_ModeloLaudoId" FOREIGN KEY ("ModeloLaudoId") REFERENCES "public"."ModeloLaudo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Lista
-- ----------------------------
ALTER TABLE "public"."Lista" ADD CONSTRAINT "FK_Lista_ClassificadorCampo_ClassificadorCampoId" FOREIGN KEY ("ClassificadorCampoId") REFERENCES "public"."ClassificadorCampo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;
ALTER TABLE "public"."Lista" ADD CONSTRAINT "FK_Lista_ModeloLaudo_ModeloLaudoId" FOREIGN KEY ("ModeloLaudoId") REFERENCES "public"."ModeloLaudo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ModeloLaudo
-- ----------------------------
ALTER TABLE "public"."ModeloLaudo" ADD CONSTRAINT "FK_ModeloLaudo_Especie_EspecieId" FOREIGN KEY ("EspecieId") REFERENCES "public"."Especie" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table Texto
-- ----------------------------
ALTER TABLE "public"."Texto" ADD CONSTRAINT "FK_Texto_ModeloLaudo_ModeloLaudoId" FOREIGN KEY ("ModeloLaudoId") REFERENCES "public"."ModeloLaudo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ValorData
-- ----------------------------
ALTER TABLE "public"."ValorData" ADD CONSTRAINT "FK_ValorData_ClassificadorCampo_ClassificadorCampoId" FOREIGN KEY ("ClassificadorCampoId") REFERENCES "public"."ClassificadorCampo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;
ALTER TABLE "public"."ValorData" ADD CONSTRAINT "FK_ValorData_LaudoPericial_LaudoPericialId" FOREIGN KEY ("LaudoPericialId") REFERENCES "public"."LaudoPericial" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ValorDecimal
-- ----------------------------
ALTER TABLE "public"."ValorDecimal" ADD CONSTRAINT "FK_ValorDecimal_ClassificadorCampo_ClassificadorCampoId" FOREIGN KEY ("ClassificadorCampoId") REFERENCES "public"."ClassificadorCampo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;
ALTER TABLE "public"."ValorDecimal" ADD CONSTRAINT "FK_ValorDecimal_LaudoPericial_LaudoPericialId" FOREIGN KEY ("LaudoPericialId") REFERENCES "public"."LaudoPericial" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table ValorLista
-- ----------------------------
ALTER TABLE "public"."ValorLista" ADD CONSTRAINT "FK_ValorLista_ClassificadorCampo_ClassificadorCampoId" FOREIGN KEY ("ClassificadorCampoId") REFERENCES "public"."ClassificadorCampo" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;
ALTER TABLE "public"."ValorLista" ADD CONSTRAINT "FK_ValorLista_ItemLista_ItemListaId" FOREIGN KEY ("ItemListaId") REFERENCES "public"."ItemLista" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;
ALTER TABLE "public"."ValorLista" ADD CONSTRAINT "FK_ValorLista_LaudoPericial_LaudoPericialId" FOREIGN KEY ("LaudoPericialId") REFERENCES "public"."LaudoPericial" ("Id") ON DELETE RESTRICT ON UPDATE NO ACTION;
