using Examen3.ServiceApp2;

namespace Examen3.ServiceApp2
{
    public class Equipo
    {
        public int Id { get; set; }
        public string NombreEquipo { get; set; }
        public string Organizacion { get; set; }
        public Participante Representante { get; set; }
        public List<Participante> Miembros { get; set; }
    }
}