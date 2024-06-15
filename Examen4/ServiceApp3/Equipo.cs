using Examen3.ServiceApp3;

namespace Examen3.ServiceApp3
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Institucion { get; set; }
        public string Representante { get; set; } // Representante del equipo
        public List<Participante> Miembros { get; set; } // Lista de miembros del equipo
        public List<Evento> Eventos { get; set; } // Historial de eventos realizados y en los que participó el equipo
        //public List<Certificado> Certificados { get; set; } // Certificados de participación por equipo
        public int EventoId { get; set; } // Foreign Key to Evento

    }
}
