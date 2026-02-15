using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteStartNet2023.Data.Migrations
{
    public partial class cualquiera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "TecnologiasPostulantes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "TecnologiasPostulantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
