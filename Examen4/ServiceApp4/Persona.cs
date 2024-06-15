
using Examen3.ServiceApp4;

namespace Examen3.ServiceApp4
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Direccion> Direcciones { get; set; }
    }
}


