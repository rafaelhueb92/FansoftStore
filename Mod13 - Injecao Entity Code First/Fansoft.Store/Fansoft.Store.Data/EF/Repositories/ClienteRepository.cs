using Fansoft.Store.Domain.Contracts;
using Fansoft.Store.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Fansoft.Store.Data.EF.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        //Para paginação => docs.microsoft.com/pt-br/aspnet/core/data/ef-mvc/sort-filter-page
        public IEnumerable<Cliente> GetByName(string contains)
        {
            return 
                _ctx.Clientes
                    .Where(c => c.Nome.ToLower().Contains(contains.ToLower()))
                    //.Skip(10) //pula 10
                    .Take(10) //Top 10
                .ToList();
        }
    }
}
