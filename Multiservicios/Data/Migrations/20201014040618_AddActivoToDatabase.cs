using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Multiservicios.Data.Migrations
{
    public partial class AddActivoToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Cantidad = table.Column<string>(nullable: true),
                    Fecha_Adquisicion = table.Column<DateTime>(nullable: false),
                    No_ = table.Column<string>(nullable: true),
                    MarcaId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    RutaFoto = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Motivo_Baja = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    ProveedorId = table.Column<int>(nullable: false),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Usuario_Creacion = table.Column<string>(nullable: true),
                    Fecha_Modificacion = table.Column<DateTime>(nullable: false),
                    Usuario_Modificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activo_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activo_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activo_CategoriaId",
                table: "Activo",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Activo_MarcaId",
                table: "Activo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Activo_ProveedorId",
                table: "Activo",
                column: "ProveedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activo");
        }
    }
}
