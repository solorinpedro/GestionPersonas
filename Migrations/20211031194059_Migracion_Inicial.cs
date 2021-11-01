using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionPersonas.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aportes",
                columns: table => new
                {
                    AporteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: true),
                    Monto = table.Column<float>(type: "REAL", nullable: false),
                    AporteDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aportes", x => x.AporteId);
                    table.ForeignKey(
                        name: "FK_Aportes_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposAportes",
                columns: table => new
                {
                    TipoAporteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Meta = table.Column<float>(type: "REAL", nullable: false),
                    Logrado = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAportes", x => x.TipoAporteId);
                });

            migrationBuilder.CreateTable(
                name: "AportesDetalle",
                columns: table => new
                {
                    AporteDetalleId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoAporteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false),
                    PersonaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AportesDetalle", x => x.AporteDetalleId);
                    table.ForeignKey(
                        name: "FK_AportesDetalle_Aportes_AporteDetalleId",
                        column: x => x.AporteDetalleId,
                        principalTable: "Aportes",
                        principalColumn: "AporteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AportesDetalle_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AportesDetalle_TiposAportes_TipoAporteId",
                        column: x => x.TipoAporteId,
                        principalTable: "TiposAportes",
                        principalColumn: "TipoAporteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aportes_PersonaId",
                table: "Aportes",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_AportesDetalle_PersonaId",
                table: "AportesDetalle",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_AportesDetalle_TipoAporteId",
                table: "AportesDetalle",
                column: "TipoAporteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AportesDetalle");

            migrationBuilder.DropTable(
                name: "Aportes");

            migrationBuilder.DropTable(
                name: "TiposAportes");
        }
    }
}
