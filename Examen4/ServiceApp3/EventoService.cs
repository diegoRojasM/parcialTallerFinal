// using System.Collections.Generic;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;
// using Examen3.ServiceApp3;

// namespace Examen3.ServiceApp3
// {
//     public class EventoService
//     {
//         private readonly ApDbContext _context;

//         public EventoService(ApDbContext context)
//         {
//             _context = context;
//         }

//         public IEnumerable<Evento> GetAll()
//         {
//             //return _context.Eventos.Include(e => e.Participantes).Include(e => e.Equipos).Where(e => e.Estado == "Activo").ToList();
//             var eventos = new List<Evento>
//             {
//                 new Evento
//                 {
//                     Id = 1,
//                     Nombre = "Evento de Tecnología",
//                     Descripcion = "Un evento sobre las últimas tendencias en tecnología.",
//                     Ubicacion = "Centro de Convenciones",
//                     InformacionContacto = "contacto@techevent.com",
//                     FechaInicio = new DateTime(2024, 7, 1),
//                     FechaFin = new DateTime(2024, 7, 3),
//                     Estado = "Activo",
//                     Tipo = "Participantes",
//                     Participantes = new List<Participante>
//                     {
//                         new Participante
//                         {
//                             Id = 1,
//                             Nombre = "Juan Pérez",
//                             Direccion = "Av. Siempre Viva 123",
//                             FechaNacimiento = new DateTime(1990, 1, 1),
//                             Correo = "juan.perez@example.com",
//                             NumeroTelefono = "123456789",
//                             Organizacion = "Tech Corp",
//                             Profesion = "Ingeniero de Software",
//                             Cargo = "Desarrollador",
//                             Eventos = null, // Aquí puedes inicializar los eventos si lo necesitas
//                             Certificados = null // Aquí puedes inicializar los certificados si lo necesitas
//                         }
//                     },
//                     Equipos = new List<Equipo>()
//                 },
//                 new Evento
//                 {
//                     Id = 2,
//                     Nombre = "Competencia de Robótica",
//                     Descripcion = "Competencia de robótica para equipos universitarios.",
//                     Ubicacion = "Universidad Central",
//                     InformacionContacto = "info@roboticscomp.com",
//                     FechaInicio = new DateTime(2024, 8, 15),
//                     FechaFin = new DateTime(2024, 8, 17),
//                     Estado = "Activo",
//                     Tipo = "Equipos",
//                     Participantes = new List<Participante>(),
//                     Equipos = new List<Equipo>
//                     {
//                         new Equipo
//                         {
//                             Id = 1,
//                             Nombre = "Equipo Alpha",
//                             Institucion = "Universidad A",
//                             Representante = null, // Aquí puedes inicializar el representante si lo necesitas
//                             Miembros = null, // Aquí puedes inicializar los miembros si lo necesitas
//                             Eventos = null, // Aquí puedes inicializar los eventos si lo necesitas
//                             Certificados = null // Aquí puedes inicializar los certificados si lo necesitas
//                         },
//                         new Equipo
//                         {
//                             Id = 2,
//                             Nombre = "Equipo Beta",
//                             Institucion = "Universidad B",
//                             Representante = null, // Aquí puedes inicializar el representante si lo necesitas
//                             Miembros = null, // Aquí puedes inicializar los miembros si lo necesitas
//                             Eventos = null, // Aquí puedes inicializar los eventos si lo necesitas
//                             Certificados = null // Aquí puedes inicializar los certificados si lo necesitas
//                         }
//                     }
//                 }
//             };

//             return eventos;
//         }

//         public Evento? GetById(int id)
//         {
//             return _context.Eventos.Include(e => e.Participantes).Include(e => e.Equipos).FirstOrDefault(e => e.Id == id);
//         }

//         public Evento CreateParaParticipantes(Evento newEvento)
//         {
//             newEvento.Tipo = "Participantes";
//             newEvento.Estado = "Activo";
//             _context.Eventos.Add(newEvento);
//             _context.SaveChanges();

//             return newEvento;
//         }

//         public Evento CreateParaEquipos(Evento newEvento)
//         {
//             newEvento.Tipo = "Equipos";
//             newEvento.Estado = "Activo";
//             _context.Eventos.Add(newEvento);
//             _context.SaveChanges();

//             return newEvento;
//         }

//         public void Update(int id, Evento evento)
//         {
//             var existingEvento = GetById(id);

//             if (existingEvento != null)
//             {
//                 existingEvento.Nombre = evento.Nombre;
//                 existingEvento.Descripcion = evento.Descripcion;
//                 existingEvento.Ubicacion = evento.Ubicacion;
//                 existingEvento.InformacionContacto = evento.InformacionContacto;
//                 existingEvento.FechaInicio = evento.FechaInicio;
//                 existingEvento.FechaFin = evento.FechaFin;
//                 existingEvento.Estado = evento.Estado;

//                 _context.SaveChanges();
//             }
//         }

//         public void Delete(int id)
//         {
//             var eventoToDelete = GetById(id);

//             if (eventoToDelete != null)
//             {
//                 _context.Eventos.Remove(eventoToDelete);
//                 _context.SaveChanges();
//             }
//         }

//         public void AddParticipante(int eventoId, Participante participante)
//         {
//             var evento = GetById(eventoId);
//             if (evento != null && evento.Tipo == "Participantes")
//             {
//                 evento.Participantes.Add(participante);
//                 _context.SaveChanges();
//             }
//         }

//         public void AddEquipo(int eventoId, Equipo equipo)
//         {
//             var evento = GetById(eventoId);
//             if (evento != null && evento.Tipo == "Equipos")
//             {
//                 evento.Equipos.Add(equipo);
//                 _context.SaveChanges();
//             }
//         }
//     }
// }

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Examen3.ServiceApp3
{
    public class EventoService
    {
        private readonly ApDbContext _context;

        public EventoService(ApDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Evento> GetAll()
        {
            return _context.Eventos
                .Include(e => e.Participantes)
                .Include(e => e.Equipos)
                .Where(e => e.Estado == "Activo")
                .ToList();
//             var eventos = new List<Evento>
//             {
//                 new Evento
//                 {
//                     Id = 1,
//                     Nombre = "Evento de Tecnología",
//                     Descripcion = "Un evento sobre las últimas tendencias en tecnología.",
//                     Ubicacion = "Centro de Convenciones",
//                     InformacionContacto = "contacto@techevent.com",
//                     FechaInicio = new DateTime(2024, 7, 1),
//                     FechaFin = new DateTime(2024, 7, 3),
//                     Estado = "Activo",
//                     Tipo = "Participantes",
//                     Participantes = new List<Participante>
//                     {
//                         new Participante
//                         {
//                             Id = 1,
//                             Nombre = "Juan Pérez",
//                             Direccion = "Av. Siempre Viva 123",
//                             FechaNacimiento = new DateTime(1990, 1, 1),
//                             Correo = "juan.perez@example.com",
//                             NumeroTelefono = "123456789",
//                             Organizacion = "Tech Corp",
//                             Profesion = "Ingeniero de Software",
//                             Cargo = "Desarrollador",
//  // Aquí puedes inicializar los certificados si lo necesitas
//                         }
//                     },
//                     Equipos = new List<Equipo>()
//                 },
//                 new Evento
//                 {
//                     Id = 2,
//                     Nombre = "Competencia de Robótica",
//                     Descripcion = "Competencia de robótica para equipos universitarios.",
//                     Ubicacion = "Universidad Central",
//                     InformacionContacto = "info@roboticscomp.com",
//                     FechaInicio = new DateTime(2024, 8, 15),
//                     FechaFin = new DateTime(2024, 8, 17),
//                     Estado = "Activo",
//                     Tipo = "Equipos",
//                     Participantes = new List<Participante>(),
//                     Equipos = new List<Equipo>
//                     {
//                         new Equipo
//                         {
//                             Id = 1,
//                             Nombre = "Equipo Alpha",
//                             Institucion = "Universidad A",
//                             Representante = null, // Aquí puedes inicializar el representante si lo necesitas
//                             Miembros = null, // Aquí puedes inicializar los miembros si lo necesitas // Aquí puedes inicializar los eventos si lo necesitas // Aquí puedes inicializar los certificados si lo necesitas
//                         },
//                         new Equipo
//                         {
//                             Id = 2,
//                             Nombre = "Equipo Beta",
//                             Institucion = "Universidad B",
//                             Representante = null, // Aquí puedes inicializar el representante si lo necesitas
//                             Miembros = null, // Aquí puedes inicializar los miembros si lo necesitas // Aquí puedes inicializar los certificados si lo necesitas
//                         }
//                     }
//                 }
//             };

//             return eventos;
        }

        public Evento GetById(int id)
        {
            return _context.Eventos
                .Include(e => e.Participantes)
                .Include(e => e.Equipos)
                .FirstOrDefault(e => e.Id == id);
        }



        public Evento CreateParaParticipantes(Evento newEvento)
        {
            newEvento.Tipo = "Participantes";
            newEvento.Estado = "Activo";
            _context.Eventos.Add(newEvento);
            _context.SaveChanges();
            return newEvento;
        }

        public Evento CreateParaEquipos(Evento newEvento)
        {
            newEvento.Tipo = "Equipos";
            newEvento.Estado = "Activo";
            _context.Eventos.Add(newEvento);
            _context.SaveChanges();
            return newEvento;
        }

        public void Update(int id, Evento evento)
        {
            var existingEvento = GetById(id);
            if (existingEvento != null)
            {
                existingEvento.Nombre = evento.Nombre;
                existingEvento.Descripcion = evento.Descripcion;
                existingEvento.Ubicacion = evento.Ubicacion;
                existingEvento.InformacionContacto = evento.InformacionContacto;
                existingEvento.FechaInicio = evento.FechaInicio;
                existingEvento.FechaFin = evento.FechaFin;
                existingEvento.Estado = evento.Estado;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var eventoToDelete = GetById(id);
            if (eventoToDelete != null)
            {
                _context.Eventos.Remove(eventoToDelete);
                _context.SaveChanges();
            }
        }

        public void AddParticipante(int eventoId, Participante participante)
        {
            var evento = GetById(eventoId);
            if (evento != null && evento.Tipo == "Participantes")
            {
                evento.Participantes.Add(participante);
                _context.SaveChanges();
            }
        }

        public void AddEquipo(int eventoId, Equipo equipo)
        {
            var evento = GetById(eventoId);
            if (evento != null && evento.Tipo == "Equipos")
            {
                evento.Equipos.Add(equipo);
                _context.SaveChanges();
            }
        }
    }
}
