using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteStartNet2023.Data.Migrations
{
    public partial class provincias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NivelesConocimiento_Postulantes_PostulanteId",
                table: "NivelesConocimiento");

            migrationBuilder.DropIndex(
                name: "IX_NivelesConocimiento_PostulanteId",
                table: "NivelesConocimiento");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "NivelConocimientoId",
                table: "Postulantes");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Postulantes");

            migrationBuilder.DropColumn(
                name: "PuestoTrabajoId",
                table: "Postulantes");

            migrationBuilder.DropColumn(
                name: "PostulanteId",
                table: "NivelesConocimiento");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "TecnologiasPostulantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "TecnologiasPostulantes");

            migrationBuilder.AddColumn<int>(
                name: "NivelConocimientoId",
                table: "Postulantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Postulantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PuestoTrabajoId",
                table: "Postulantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PostulanteId",
                table: "NivelesConocimiento",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NivelesConocimiento_PostulanteId",
                table: "NivelesConocimiento",
                column: "PostulanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_NivelesConocimiento_Postulantes_PostulanteId",
                table: "NivelesConocimiento",
                column: "PostulanteId",
                principalTable: "Postulantes",
                principalColumn: "Id");
        }
    }
}
