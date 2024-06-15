using Examen3.ServiceApp3;

namespace Examen3.ServiceApp3
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Institucion { get; set; }
        public string Representante { get; set; } // Representante del equipo
        public int ParticipantesId { get;}
        public List<Participante> Participantes { get; set; } // Lista de miembros del equipo
        //public List<Evento> Eventos { get; set; } // Historial de eventos realizados y en los que participó el equipo
        public List<Certificado> Certificados { get; set; } // Certificados de participación por equipo
        public int EventoId { get; set; } // Relación con equipo (si es de equipo)
        public Evento Evento { get; set; }

    }
}
