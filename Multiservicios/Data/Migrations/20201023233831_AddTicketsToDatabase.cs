using Microsoft.EntityFrameworkCore.Migrations;

namespace Multiservicios.Data.Migrations
{
    public partial class AddTicketsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoSolicitud",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NOMBRE_SOLICITUD = table.Column<string>(nullable: true),
                    DESCRIPCION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSolicitud", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ACTIVO = table.Column<int>(nullable: false),
                    ID_TIPO_SOLICITUD = table.Column<int>(nullable: false),
                    NO_SERIE = table.Column<string>(nullable: true),
                    USUARIO_ASIGNACION = table.Column<int>(nullable: false),
                    ID_ACTIVIDAD = table.Column<int>(nullable: false),
                    DESCRIPCION = table.Column<string>(nullable: true),
                    ID_PROCESO = table.Column<int>(nullable: false),
                    ESTADO = table.Column<string>(nullable: true),
                    FECHA_CREACION = table.Column<string>(nullable: true),
                    USUARIO_CREACION = table.Column<int>(nullable: false),
                    FECHA_MODIFICACION = table.Column<string>(nullable: true),
                    USUARIO_MODIFICACION = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tickets_Activo_ID_ACTIVO",
                        column: x => x.ID_ACTIVO,
                        principalTable: "Activo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_TipoSolicitud_ID_TIPO_SOLICITUD",
                        column: x => x.ID_TIPO_SOLICITUD,
                        principalTable: "TipoSolicitud",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ID_ACTIVO",
                table: "Tickets",
                column: "ID_ACTIVO");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ID_TIPO_SOLICITUD",
                table: "Tickets",
                column: "ID_TIPO_SOLICITUD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TipoSolicitud");
        }
    }
}
