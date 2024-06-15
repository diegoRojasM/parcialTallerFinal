using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen3.Migrations.ApDb
{
    /// <inheritdoc />
    public partial class Inictial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificado_Equipos_EquipoId",
                table: "Certificado");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificado_Participantes_ParticipanteId",
                table: "Certificado");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Eventos_EventoId",
                table: "Equipos");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Equipos_EquipoId",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Eventos_EventoId",
                table: "Participantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participantes",
                table: "Participantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos");

            migrationBuilder.RenameTable(
                name: "Participantes",
                newName: "Participante");

            migrationBuilder.RenameTable(
                name: "Equipos",
                newName: "Equipo");

            migrationBuilder.RenameIndex(
                name: "IX_Participantes_EventoId",
                table: "Participante",
                newName: "IX_Participante_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Participantes_EquipoId",
                table: "Participante",
                newName: "IX_Participante_EquipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipos_EventoId",
                table: "Equipo",
                newName: "IX_Equipo_EventoId");

            migrationBuilder.AddColumn<int>(
                name: "CertificadoId",
                table: "Participante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participante",
                table: "Participante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificado_Equipo_EquipoId",
                table: "Certificado",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificado_Participante_ParticipanteId",
                table: "Certificado",
                column: "ParticipanteId",
                principalTable: "Participante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Eventos_EventoId",
                table: "Equipo",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participante_Equipo_EquipoId",
                table: "Participante",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participante_Eventos_EventoId",
                table: "Participante",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificado_Equipo_EquipoId",
                table: "Certificado");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificado_Participante_ParticipanteId",
                table: "Certificado");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Eventos_EventoId",
                table: "Equipo");

            migrationBuilder.DropForeignKey(
                name: "FK_Participante_Equipo_EquipoId",
                table: "Participante");

            migrationBuilder.DropForeignKey(
                name: "FK_Participante_Eventos_EventoId",
                table: "Participante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participante",
                table: "Participante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "CertificadoId",
                table: "Participante");

            migrationBuilder.RenameTable(
                name: "Participante",
                newName: "Participantes");

            migrationBuilder.RenameTable(
                name: "Equipo",
                newName: "Equipos");

            migrationBuilder.RenameIndex(
                name: "IX_Participante_EventoId",
                table: "Participantes",
                newName: "IX_Participantes_EventoId");

            migrationBuilder.RenameIndex(
                name: "IX_Participante_EquipoId",
                table: "Participantes",
                newName: "IX_Participantes_EquipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipo_EventoId",
                table: "Equipos",
                newName: "IX_Equipos_EventoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participantes",
                table: "Participantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificado_Equipos_EquipoId",
                table: "Certificado",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificado_Participantes_ParticipanteId",
                table: "Certificado",
                column: "ParticipanteId",
                principalTable: "Participantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Eventos_EventoId",
                table: "Equipos",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Equipos_EquipoId",
                table: "Participantes",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Eventos_EventoId",
                table: "Participantes",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id");
        }
    }
}
