using Examen3.ServiceApp2;
using Examen3.ServiceApp2.Contrato;

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Cookies;


namespace Examen3.Controllers
{
    

    public class InicioControler: Controller
    {
        private readonly Task<IUsuarioService> _usuarioServicio;
        public InicioControler(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Clave = Utilidades.EncriptarClave(modelo.Clave);

            Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

            if(usuario_creado.Id > 0)
                return RedirectToAction("IniciarSesion","Inicio");
            
            ViewData["Mensaje"]="No se pudo crear el usuario"

            return View();
        }
        public IActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        public async IActionResult IniciarSesion(string correo,string clave)
        {
            Usuario usuario_encontrado = await _usuarioServicio.GetUsuario(correo,Utilidades.EncriptarClave(clave));

            if(usuario_encontrado == null){
                return ViewData["Mensaje"]="No se encontraron coincidencias"
                return View();
            } 

            List<Claim> claims = new List<Claim>(){
                new Claim(ClaimTypes.Name,usuario_encontrado.Nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties(){
                AllowRefresh = true;
            };
            
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                new ClaimsPrincipal(claimsIdentity), 
                properties;
            );
            return RedirectToAction("Index","Home");
        }
    }
}