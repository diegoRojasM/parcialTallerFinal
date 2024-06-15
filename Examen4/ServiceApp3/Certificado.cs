using Examen3.ServiceApp3;

namespace Examen3.ServiceApp3
{
    public class Certificado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaEmision { get; set; }
        public int ParticipanteId { get; set; } // Relación con participante (si es individual)
        public Participante Participante { get; set; }
        public int EquipoId { get; set; } // Relación con equipo (si es de equipo)
        public Equipo Equipo { get; set; }
    }
}