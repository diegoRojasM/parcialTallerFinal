
using Microsoft.AspNetCore.Mvc;
using Examen3.ServiceApp2;
using Examen3.ServiceApp2.Implementacion;


namespace Examen3.Controllers
{
    [ApiController]
    [Route("eventos")]
    public class EventosController : ControllerBase
    {
        private readonly UsuarioService _service;
        public EventosController (UsuarioService service){
            _service = service;
        }
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _service.GetAll();
        }

    }
}