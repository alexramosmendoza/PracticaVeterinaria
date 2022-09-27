using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticaVeterinaria.app.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "propietarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "veterinarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false),
                    tarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "mascotas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    especie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    propietarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mascotas", x => x.id);
                    table.ForeignKey(
                        name: "FK_mascotas_propietarios_propietarioid",
                        column: x => x.propietarioid,
                        principalTable: "propietarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "historiasclinicas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mascotaid = table.Column<int>(type: "int", nullable: true),
                    fechaDeCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historiasclinicas", x => x.id);
                    table.ForeignKey(
                        name: "FK_historiasclinicas_mascotas_mascotaid",
                        column: x => x.mascotaid,
                        principalTable: "mascotas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "visitas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    temperatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    peso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    frecRespiratoria = table.Column<int>(type: "int", nullable: false),
                    frecCardiaca = table.Column<int>(type: "int", nullable: false),
                    estadoAnimo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaVisita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    formulaMedica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    historiaClinicaid = table.Column<int>(type: "int", nullable: true),
                    veterinarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitas", x => x.id);
                    table.ForeignKey(
                        name: "FK_visitas_historiasclinicas_historiaClinicaid",
                        column: x => x.historiaClinicaid,
                        principalTable: "historiasclinicas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_visitas_veterinarios_veterinarioid",
                        column: x => x.veterinarioid,
                        principalTable: "veterinarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_historiasclinicas_mascotaid",
                table: "historiasclinicas",
                column: "mascotaid");

            migrationBuilder.CreateIndex(
                name: "IX_mascotas_propietarioid",
                table: "mascotas",
                column: "propietarioid");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_historiaClinicaid",
                table: "visitas",
                column: "historiaClinicaid");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_veterinarioid",
                table: "visitas",
                column: "veterinarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "visitas");

            migrationBuilder.DropTable(
                name: "historiasclinicas");

            migrationBuilder.DropTable(
                name: "veterinarios");

            migrationBuilder.DropTable(
                name: "mascotas");

            migrationBuilder.DropTable(
                name: "propietarios");
        }
    }
}
