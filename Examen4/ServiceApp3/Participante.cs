using Examen3.ServiceApp3;

namespace Examen3.ServiceApp3
{
    public class Participante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string NumeroTelefono { get; set; }
        public string Organizacion { get; set; }
        public string Profesion { get; set; }
        public string Cargo { get; set; }
        //public List<Evento> Eventos { get; set; } // Historial de eventos realizados y en los que participó el usuario
        public int CertificadoId { get; set; }
        public List<Certificado> Certificados { get; set; } // Certificados de participación individual
        public int EventoId { get; set; } // Foreign Key to Evento
        public Evento Evento { get; set; }

    }

}


