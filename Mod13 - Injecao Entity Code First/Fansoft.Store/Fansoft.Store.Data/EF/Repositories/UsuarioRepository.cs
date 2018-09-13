using Fansoft.Store.Domain.Contracts;
using Fansoft.Store.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public Usuario GetbyEmail(string email)
        {
            return _ctx.Usuarios.FirstOrDefault(e => e.Email.ToLower() == email.ToLower());
        }

        public IEnumerable<Usuario> GetbyName(string name)
        {
            return

                //(from u in _ctx.Usuarios
                // where u.Nome.Contains(name)
                // select u).ToList();

                _ctx.Usuarios
                    .Where(u => u.Nome.ToLower().Contains(name.ToLower()))
                    .ToList();
        }
    }
}
