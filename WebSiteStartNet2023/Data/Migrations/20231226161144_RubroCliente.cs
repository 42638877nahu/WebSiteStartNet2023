using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteStartNet2023.Data.Migrations
{
    public partial class RubroCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SubArea",
                table: "Contactos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Contactos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdRubroCliente",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "VisibleEnHome",
                table: "Clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "RubrosClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RubrosClientes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdRubroCliente",
                table: "Clientes",
                column: "IdRubroCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_RubrosClientes_IdRubroCliente",
                table: "Clientes",
                column: "IdRubroCliente",
                principalTable: "RubrosClientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_RubrosClientes_IdRubroCliente",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "RubrosClientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdRubroCliente",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdRubroCliente",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "VisibleEnHome",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "SubArea",
                table: "Contactos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Area",
                table: "Contactos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
