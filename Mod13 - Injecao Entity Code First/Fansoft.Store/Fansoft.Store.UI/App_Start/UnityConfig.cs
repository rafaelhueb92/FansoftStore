using EF = Fansoft.Store.Data.EF.Repositories;
using ADO = Fansoft.Store.Data.ADO.Repositories;
using Fansoft.Store.Domain.Contracts;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Fansoft.Store.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //container.RegisterType<IProdutoRepository, ADO.ProdutoRepository>();
            container.RegisterType<IProdutoRepository, EF.ProdutoRepository>();
            container.RegisterType<ITipoProdutoRepository, EF.TipoProdutoRepository>();
            container.RegisterType<IClienteRepository, EF.ClienteRepository>();
            container.RegisterType<IPedidoRepository, EF.PedidoRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}