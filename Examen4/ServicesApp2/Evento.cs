using Examen3.ServiceApp2;

namespace Examen3.ServiceApp2
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string InformacionContacto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdCreador { get; set; } // ID del usuario creador
        public Usuario Creador { get; set; } // Relación con el usuario creador
        public List<Participante> Participantes { get; set; }

    }
}