using Microsoft.EntityFrameworkCore;
using Examen3.ServiceApp2;

namespace Examen3.ServiceApp2.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo,string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);
    }
}