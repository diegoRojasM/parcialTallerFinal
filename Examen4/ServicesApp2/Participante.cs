using Examen3.ServiceApp2;

namespace Examen3.ServiceApp2
{
    public class Participante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroTelefono { get; set; }
        public string Organizacion { get; set; }
        public string Profesion { get; set; }
        public string Cargo { get; set; }
    }
}