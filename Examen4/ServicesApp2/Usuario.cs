using Examen3.ServiceApp2;

namespace Examen3.ServiceApp2
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Clave { get; set; }
        public List<Evento> EventosCreados { get; set; }

    }
}