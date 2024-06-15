using System;
using System.Collections.Generic;
using Examen3.ServiceApp3;

namespace Examen3.ServiceApp3
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
        public string Estado { get; set; } // Estado del evento: Activo o Inactivo
        public string Tipo { get; set; } // Tipo del evento: Participantes o Equipos
        //public int IdCreador { get; set; } // ID del usuario creador
        //public Usuario Creador { get; set; } // Relación con el usuario creador
        public List<Participante> Participantes { get; set; }
        public List<Equipo> Equipos { get; set; }


    }
}


