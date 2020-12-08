using Microsoft.EntityFrameworkCore.Migrations;

namespace Sol.NHI.ApiPersona.Migrations
{
    public partial class SQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPersona = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApellidoPaterno = table.Column<string>(nullable: true),
                    ApellidoMaterno = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPersona);
                });

            migrationBuilder.InsertData(
                table: "Persona",
                columns: new[] { "IdPersona", "ApellidoMaterno", "ApellidoPaterno", "Nombres" },
                values: new object[] { 1, "Gomez", "Perez", "Juan Perez" });

            migrationBuilder.InsertData(
                table: "Persona",
                columns: new[] { "IdPersona", "ApellidoMaterno", "ApellidoPaterno", "Nombres" },
                values: new object[] { 2, "Caceres", "Lopez", "Maria" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
