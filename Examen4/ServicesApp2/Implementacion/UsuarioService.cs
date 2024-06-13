using Microsoft.EntityFrameworkCore;
using Examen3.ServiceApp2.Contrato;
using Examen3.ServiceApp2;

namespace Examen3.ServiceApp2.Implementacion
{
    public class UsuarioService: IUsuarioService
    {
        public readonly ApplicationDbContext _dbContext;
        public UsuarioService(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Usuario> GetUsuario(string correo,string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.CorreoElectronico == correo 
            && u.Clave == clave).FirstOrDefaultAsync();

            return usuario_encontrado;
        }
        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuario.Add(modelo);
            await _dbContext _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}