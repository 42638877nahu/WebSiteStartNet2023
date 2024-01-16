using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteStartNet2023.Data.Migrations
{
    public partial class ReEstructuracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Servicios",
                newName: "NombreSlider");

            migrationBuilder.RenameColumn(
                name: "NombreFoto",
                table: "Servicios",
                newName: "NombreHome");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Novedades",
                newName: "Detalle");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "CVs",
                newName: "TeléfonoCelular");

            migrationBuilder.AddColumn<string>(
                name: "Detalle",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "CVs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detalle",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "CVs");

            migrationBuilder.RenameColumn(
                name: "NombreSlider",
                table: "Servicios",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "NombreHome",
                table: "Servicios",
                newName: "NombreFoto");

            migrationBuilder.RenameColumn(
                name: "Detalle",
                table: "Novedades",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "TeléfonoCelular",
                table: "CVs",
                newName: "Celular");
        }
    }
}
