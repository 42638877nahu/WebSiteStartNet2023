using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteStartNet2023.Data.Migrations
{
    public partial class RelacionesPostulante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_NivelesConocimiento_Postulantes_PostulanteId",
                table: "NivelesConocimiento",
                column: "PostulanteId",
                principalTable: "Postulantes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NivelesConocimiento_Postulantes_PostulanteId",
                table: "NivelesConocimiento");

            migrationBuilder.DropIndex(
                name: "IX_NivelesConocimiento_PostulanteId",
                table: "NivelesConocimiento");

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
        }
    }
}
