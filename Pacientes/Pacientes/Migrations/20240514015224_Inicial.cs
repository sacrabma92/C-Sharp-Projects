using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pacientes.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alimentaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dietas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ejercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ejercicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cedula = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechanac = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposEnfermedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlimentacionId = table.Column<int>(type: "int", nullable: false),
                    DietaId = table.Column<int>(type: "int", nullable: false),
                    EnfermedadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEnfermedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposEnfermedades_Alimentaciones_AlimentacionId",
                        column: x => x.AlimentacionId,
                        principalTable: "Alimentaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposEnfermedades_Dietas_DietaId",
                        column: x => x.DietaId,
                        principalTable: "Dietas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TiposEnfermedades_Enfermedades_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "Enfermedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Imc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    peso = table.Column<double>(type: "float", nullable: false),
                    altura = table.Column<double>(type: "float", nullable: false),
                    totalimc = table.Column<double>(type: "float", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Imc_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PacientesPesos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietaId = table.Column<int>(type: "int", nullable: false),
                    EjerciciosId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacientesPesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacientesPesos_Dietas_DietaId",
                        column: x => x.DietaId,
                        principalTable: "Dietas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacientesPesos_Ejercicios_EjerciciosId",
                        column: x => x.EjerciciosId,
                        principalTable: "Ejercicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacientesPesos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alimentaciones",
                columns: new[] { "Id", "nombre" },
                values: new object[,]
                {
                    { 1, "fruta" },
                    { 2, "verdura" },
                    { 3, "granos" },
                    { 4, "proteinas magras" },
                    { 5, "grasas saludables" },
                    { 6, "azúcar" },
                    { 7, "alimentos procesados" },
                    { 8, "agua" },
                    { 9, "lacteos" }
                });

            migrationBuilder.InsertData(
                table: "Dietas",
                columns: new[] { "Id", "nombre" },
                values: new object[,]
                {
                    { 1, "peso bajo" },
                    { 2, "peso normal" },
                    { 3, "sobre peso" },
                    { 4, "obesidad" }
                });

            migrationBuilder.InsertData(
                table: "Ejercicios",
                columns: new[] { "Id", "nombre" },
                values: new object[,]
                {
                    { 1, "caminar" },
                    { 2, "correr" },
                    { 3, "nadar" },
                    { 4, "yoga" },
                    { 5, "gimnacio" }
                });

            migrationBuilder.InsertData(
                table: "Enfermedades",
                columns: new[] { "Id", "nombre" },
                values: new object[,]
                {
                    { 1, "desnutricion" },
                    { 2, "anorexia" },
                    { 3, "bulimia" },
                    { 4, "depresion" },
                    { 5, "ansiedad" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imc_PacienteId",
                table: "Imc",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesPesos_DietaId",
                table: "PacientesPesos",
                column: "DietaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesPesos_EjerciciosId",
                table: "PacientesPesos",
                column: "EjerciciosId");

            migrationBuilder.CreateIndex(
                name: "IX_PacientesPesos_PacienteId",
                table: "PacientesPesos",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposEnfermedades_AlimentacionId",
                table: "TiposEnfermedades",
                column: "AlimentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposEnfermedades_DietaId",
                table: "TiposEnfermedades",
                column: "DietaId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposEnfermedades_EnfermedadId",
                table: "TiposEnfermedades",
                column: "EnfermedadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imc");

            migrationBuilder.DropTable(
                name: "PacientesPesos");

            migrationBuilder.DropTable(
                name: "TiposEnfermedades");

            migrationBuilder.DropTable(
                name: "Ejercicios");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Alimentaciones");

            migrationBuilder.DropTable(
                name: "Dietas");

            migrationBuilder.DropTable(
                name: "Enfermedades");
        }
    }
}
