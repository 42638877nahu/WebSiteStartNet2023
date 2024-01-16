using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteStartNet2023.Data.Migrations
{
    public partial class Servicios1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreFoto",
                table: "Servicios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreFoto",
                table: "Servicios");
        }
    }
}
