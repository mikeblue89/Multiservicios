using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Multiservicios.Data.Migrations
{
    public partial class AddUsuarioToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    PuestoId = table.Column<int>(nullable: false),
                    AreaTrabajoId = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaMod = table.Column<DateTime>(nullable: false),
                    UsuarioCreacion = table.Column<string>(nullable: true),
                    UsuarioMod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_AreaTrabajo_AreaTrabajoId",
                        column: x => x.AreaTrabajoId,
                        principalTable: "AreaTrabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Usuario_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Usuario_Puesto_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puesto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_AreaTrabajoId",
                table: "Usuario",
                column: "AreaTrabajoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_DepartamentoId",
                table: "Usuario",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PuestoId",
                table: "Usuario",
                column: "PuestoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
