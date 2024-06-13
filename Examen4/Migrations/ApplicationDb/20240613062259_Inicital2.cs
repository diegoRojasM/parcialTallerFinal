using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen3.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class Inicital2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCreador",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_EventoId",
                table: "Participantes",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdCreador",
                table: "Eventos",
                column: "IdCreador");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Usuarios_IdCreador",
                table: "Eventos",
                column: "IdCreador",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Eventos_EventoId",
                table: "Participantes",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Usuarios_IdCreador",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Eventos_EventoId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_EventoId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_IdCreador",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "IdCreador",
                table: "Eventos");
        }
    }
}
