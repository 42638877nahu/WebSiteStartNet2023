using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteStartNet2023.Data.Migrations
{
    public partial class migracionNiveles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NivelEscrito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelEscrito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelLectura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelLectura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NivelOral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelOral", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdiomasPostulantes_NivelEscrituraId",
                table: "IdiomasPostulantes",
                column: "NivelEscrituraId");

            migrationBuilder.CreateIndex(
                name: "IX_IdiomasPostulantes_NivelLecturaId",
                table: "IdiomasPostulantes",
                column: "NivelLecturaId");

            migrationBuilder.CreateIndex(
                name: "IX_IdiomasPostulantes_NivelOralId",
                table: "IdiomasPostulantes",
                column: "NivelOralId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdiomasPostulantes_NivelEscrito_NivelEscrituraId",
                table: "IdiomasPostulantes",
                column: "NivelEscrituraId",
                principalTable: "NivelEscrito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdiomasPostulantes_NivelLectura_NivelLecturaId",
                table: "IdiomasPostulantes",
                column: "NivelLecturaId",
                principalTable: "NivelLectura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdiomasPostulantes_NivelOral_NivelOralId",
                table: "IdiomasPostulantes",
                column: "NivelOralId",
                principalTable: "NivelOral",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdiomasPostulantes_NivelEscrito_NivelEscrituraId",
                table: "IdiomasPostulantes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdiomasPostulantes_NivelLectura_NivelLecturaId",
                table: "IdiomasPostulantes");

            migrationBuilder.DropForeignKey(
                name: "FK_IdiomasPostulantes_NivelOral_NivelOralId",
                table: "IdiomasPostulantes");

            migrationBuilder.DropTable(
                name: "NivelEscrito");

            migrationBuilder.DropTable(
                name: "NivelLectura");

            migrationBuilder.DropTable(
                name: "NivelOral");

            migrationBuilder.DropIndex(
                name: "IX_IdiomasPostulantes_NivelEscrituraId",
                table: "IdiomasPostulantes");

            migrationBuilder.DropIndex(
                name: "IX_IdiomasPostulantes_NivelLecturaId",
                table: "IdiomasPostulantes");

            migrationBuilder.DropIndex(
                name: "IX_IdiomasPostulantes_NivelOralId",
                table: "IdiomasPostulantes");
        }
    }
}
