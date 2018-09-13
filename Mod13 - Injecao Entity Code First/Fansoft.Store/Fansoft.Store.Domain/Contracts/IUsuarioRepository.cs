using Fansoft.Store.Domain.Entities;
using System.Collections.Generic;

namespace Fansoft.Store.Domain.Contracts
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetbyName(string name);
        Usuario GetbyEmail(string email);
    }
}
