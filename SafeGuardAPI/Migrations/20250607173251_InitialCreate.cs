using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeGuardAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALERTA",
                columns: table => new
                {
                    ID_ALERTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MENSAGEM = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DATA_ALERTA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ID_RISCO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALERTA", x => x.ID_ALERTA);
                });

            migrationBuilder.CreateTable(
                name: "TB_ESTACAO",
                columns: table => new
                {
                    ID_ESTACAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTACAO", x => x.ID_ESTACAO);
                });

            migrationBuilder.CreateTable(
                name: "TB_LEITURA",
                columns: table => new
                {
                    ID_LEITURA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_SENSOR = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DATA_HORA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    VALOR = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LEITURA", x => x.ID_LEITURA);
                });

            migrationBuilder.CreateTable(
                name: "TB_RISCO",
                columns: table => new
                {
                    ID_RISCO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_ESTACAO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NIVEL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RISCO", x => x.ID_RISCO);
                });

            migrationBuilder.CreateTable(
                name: "TB_SENSOR",
                columns: table => new
                {
                    ID_SENSOR = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TIPO_SENSOR = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ID_ESTACAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SENSOR", x => x.ID_SENSOR);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALERTA");

            migrationBuilder.DropTable(
                name: "TB_ESTACAO");

            migrationBuilder.DropTable(
                name: "TB_LEITURA");

            migrationBuilder.DropTable(
                name: "TB_RISCO");

            migrationBuilder.DropTable(
                name: "TB_SENSOR");
        }
    }
}
