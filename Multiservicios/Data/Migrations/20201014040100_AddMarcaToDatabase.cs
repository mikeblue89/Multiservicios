using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Multiservicios.Data.Migrations
{
    public partial class AddMarcaToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Usuario_Creacion = table.Column<string>(nullable: true),
                    Fecha_Modificacion = table.Column<DateTime>(nullable: false),
                    Usuario_Modificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Tipo_Activo = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Usuario_Creacion = table.Column<string>(nullable: true),
                    Fecha_Modificacion = table.Column<DateTime>(nullable: false),
                    Usuario_Modificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    NombreContacto = table.Column<string>(nullable: true),
                    CorreoContacto = table.Column<string>(nullable: true),
                    TelefonoContacto = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
