using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MascotaFeliz.App.Persistencia.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VisitasPyP",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaVisita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    temperatura = table.Column<float>(type: "real", nullable: false),
                    peso = table.Column<float>(type: "real", nullable: false),
                    frecuenciaRespiratoria = table.Column<float>(type: "real", nullable: false),
                    frecuenciaCardiaca = table.Column<float>(type: "real", nullable: false),
                    estadoAnimo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idVeterinario = table.Column<int>(type: "int", nullable: false),
                    recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Historiaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitasPyP", x => x.id);
                    table.ForeignKey(
                        name: "FK_VisitasPyP_Historias_Historiaid",
                        column: x => x.Historiaid,
                        principalTable: "Historias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    especie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    raza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duenoid = table.Column<int>(type: "int", nullable: true),
                    veterinarioid = table.Column<int>(type: "int", nullable: true),
                    historiaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Historias_historiaid",
                        column: x => x.historiaid,
                        principalTable: "Historias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascotas_Personas_duenoid",
                        column: x => x.duenoid,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascotas_Personas_veterinarioid",
                        column: x => x.veterinarioid,
                        principalTable: "Personas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_duenoid",
                table: "Mascotas",
                column: "duenoid");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_historiaid",
                table: "Mascotas",
                column: "historiaid");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_veterinarioid",
                table: "Mascotas",
                column: "veterinarioid");

            migrationBuilder.CreateIndex(
                name: "IX_VisitasPyP_Historiaid",
                table: "VisitasPyP",
                column: "Historiaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "VisitasPyP");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Historias");
        }
    }
}
