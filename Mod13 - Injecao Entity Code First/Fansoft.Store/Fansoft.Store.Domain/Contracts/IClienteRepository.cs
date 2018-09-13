using Fansoft.Store.Domain.Entities;
using System.Collections.Generic;

namespace Fansoft.Store.Domain.Contracts
{
    public interface IClienteRepository:IRepository<Cliente>
    {
        IEnumerable<Cliente> GetByName(string contains);
    }
}
