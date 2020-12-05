using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoNHl.ApiOperacion.Migrations
{
    public partial class Sql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    IdOperacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCuentaOrigen = table.Column<int>(nullable: false),
                    IdCuentaDestino = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    FechaOperacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.IdOperacion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operacion");
        }
    }
}
