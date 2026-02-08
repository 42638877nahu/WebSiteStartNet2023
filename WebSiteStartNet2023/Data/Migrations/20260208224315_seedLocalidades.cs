using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSiteStartNet2023.Data.Migrations
{
    public partial class seedLocalidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Buenos Aires" },
                    { 2, "Catamarca" },
                    { 3, "Chaco" },
                    { 4, "Chubut" },
                    { 5, "Córdoba" },
                    { 6, "Corrientes" },
                    { 7, "Entre Ríos" },
                    { 8, "Formosa" },
                    { 9, "Jujuy" },
                    { 10, "La Pampa" },
                    { 11, "La Rioja" },
                    { 12, "Mendoza" },
                    { 13, "Misiones" },
                    { 14, "Neuquén" },
                    { 15, "Río Negro" },
                    { 16, "Salta" },
                    { 17, "San Juan" },
                    { 18, "San Luis" },
                    { 19, "Santa Cruz" },
                    { 20, "Santa Fe" },
                    { 21, "Santiago del Estero" },
                    { 22, "Tierra del Fuego" },
                    { 23, "Tucumán" },
                    { 24, "Ciudad Autónoma de Buenos Aires" }
                });

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "Id", "CodigoPostal", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 1, "1900", "La Plata", 1 },
                    { 2, "7600", "Mar del Plata", 1 },
                    { 3, "8000", "Bahía Blanca", 1 },
                    { 4, "7000", "Tandil", 1 },
                    { 5, "1642", "San Isidro", 1 },
                    { 6, "4700", "San Fernando del Valle", 2 },
                    { 7, "4750", "Belén", 2 },
                    { 8, "4740", "Andalgalá", 2 },
                    { 9, "5340", "Tinogasta", 2 },
                    { 10, "4715", "Recreo", 2 },
                    { 11, "3500", "Resistencia", 3 },
                    { 12, "3700", "Presidencia Roque Sáenz Peña", 3 },
                    { 13, "3540", "Villa Ángela", 3 },
                    { 14, "3730", "Charata", 3 },
                    { 15, "3509", "General San Martín", 3 },
                    { 16, "9103", "Rawson", 4 },
                    { 17, "9100", "Trelew", 4 },
                    { 18, "9120", "Puerto Madryn", 4 },
                    { 19, "9000", "Comodoro Rivadavia", 4 },
                    { 20, "9200", "Esquel", 4 },
                    { 21, "5000", "Córdoba Capital", 5 },
                    { 22, "5152", "Villa Carlos Paz", 5 },
                    { 23, "5800", "Río Cuarto", 5 },
                    { 24, "2400", "San Francisco", 5 },
                    { 25, "5900", "Villa María", 5 },
                    { 26, "3400", "Corrientes Capital", 6 },
                    { 27, "3450", "Goya", 6 },
                    { 28, "3230", "Paso de los Libres", 6 },
                    { 29, "3470", "Mercedes", 6 },
                    { 30, "3302", "Ituzaingó", 6 },
                    { 31, "3100", "Paraná", 7 },
                    { 32, "3200", "Concordia", 7 },
                    { 33, "2820", "Gualeguaychú", 7 },
                    { 34, "3260", "Concepción del Uruguay", 7 },
                    { 35, "3153", "Victoria", 7 },
                    { 36, "3600", "Formosa Capital", 8 },
                    { 37, "3610", "Clorinda", 8 },
                    { 38, "3620", "Pirané", 8 },
                    { 39, "3630", "Las Lomitas", 8 },
                    { 40, "3603", "El Colorado", 8 },
                    { 41, "4600", "San Salvador de Jujuy", 9 },
                    { 42, "4612", "Palpalá", 9 }
                });

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "Id", "CodigoPostal", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 43, "4608", "Perico", 9 },
                    { 44, "4512", "Libertador General San Martín", 9 },
                    { 45, "4650", "La Quiaca", 9 },
                    { 46, "6300", "Santa Rosa", 10 },
                    { 47, "6360", "General Pico", 10 },
                    { 48, "6303", "Toay", 10 },
                    { 49, "6200", "Realicó", 10 },
                    { 50, "6319", "Victorica", 10 },
                    { 51, "5300", "La Rioja Capital", 11 },
                    { 52, "5360", "Chilecito", 11 },
                    { 53, "5310", "Aimogasta", 11 },
                    { 54, "5380", "Chamical", 11 },
                    { 55, "5470", "Chepes", 11 },
                    { 56, "5500", "Mendoza Capital", 12 },
                    { 57, "5600", "San Rafael", 12 },
                    { 58, "5501", "Godoy Cruz", 12 },
                    { 59, "5515", "Maipú", 12 },
                    { 60, "5507", "Luján de Cuyo", 12 },
                    { 61, "3300", "Posadas", 13 },
                    { 62, "3360", "Oberá", 13 },
                    { 63, "3380", "Eldorado", 13 },
                    { 64, "3370", "Puerto Iguazú", 13 },
                    { 65, "3350", "Apóstoles", 13 },
                    { 66, "8300", "Neuquén Capital", 14 },
                    { 67, "8370", "San Martín de los Andes", 14 },
                    { 68, "8407", "Villa La Angostura", 14 },
                    { 69, "8322", "Cutral Có", 14 },
                    { 70, "8340", "Zapala", 14 },
                    { 71, "8500", "Viedma", 15 },
                    { 72, "8400", "San Carlos de Bariloche", 15 },
                    { 73, "8332", "General Roca", 15 },
                    { 74, "8324", "Cipolletti", 15 },
                    { 75, "8336", "Villa Regina", 15 },
                    { 76, "4400", "Salta Capital", 16 },
                    { 77, "4560", "Tartagal", 16 },
                    { 78, "4530", "Orán", 16 },
                    { 79, "4440", "Metán", 16 },
                    { 80, "4427", "Cafayate", 16 },
                    { 81, "5400", "San Juan Capital", 17 },
                    { 82, "5425", "Rawson", 17 },
                    { 83, "5407", "Rivadavia", 17 },
                    { 84, "5429", "Pocito", 17 }
                });

            migrationBuilder.InsertData(
                table: "Localidades",
                columns: new[] { "Id", "CodigoPostal", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 85, "5442", "Caucete", 17 },
                    { 86, "5700", "San Luis Capital", 18 },
                    { 87, "5730", "Villa Mercedes", 18 },
                    { 88, "5881", "Merlo", 18 },
                    { 89, "5710", "La Punta", 18 },
                    { 90, "5711", "Quines", 18 },
                    { 91, "9400", "Río Gallegos", 19 },
                    { 92, "9011", "Caleta Olivia", 19 },
                    { 93, "9405", "El Calafate", 19 },
                    { 94, "9050", "Puerto Deseado", 19 },
                    { 95, "9015", "Pico Truncado", 19 },
                    { 96, "2000", "Rosario", 20 },
                    { 97, "3000", "Santa Fe Capital", 20 },
                    { 98, "2300", "Rafaela", 20 },
                    { 99, "2600", "Venado Tuerto", 20 },
                    { 100, "3560", "Reconquista", 20 },
                    { 101, "4200", "Santiago del Estero Capital", 21 },
                    { 102, "4300", "La Banda", 21 },
                    { 103, "4220", "Termas de Río Hondo", 21 },
                    { 104, "3760", "Añatuya", 21 },
                    { 105, "4230", "Frías", 21 },
                    { 106, "9410", "Ushuaia", 22 },
                    { 107, "9420", "Río Grande", 22 },
                    { 108, "9421", "Tolhuin", 22 },
                    { 109, "9425", "San Sebastián", 22 },
                    { 110, "9412", "Lago Escondido", 22 },
                    { 111, "4000", "San Miguel de Tucumán", 23 },
                    { 112, "4107", "Yerba Buena", 23 },
                    { 113, "4103", "Tafí Viejo", 23 },
                    { 114, "4146", "Concepción", 23 },
                    { 115, "4142", "Monteros", 23 },
                    { 116, "1425", "Palermo", 24 },
                    { 117, "1113", "Recoleta", 24 },
                    { 118, "1405", "Caballito", 24 },
                    { 119, "1428", "Belgrano", 24 },
                    { 120, "1068", "San Telmo", 24 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
