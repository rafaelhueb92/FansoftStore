using Fansoft.Store.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fansoft.Store.UI.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IPedidoRepository _pedidoRepo;
        private readonly IProdutoRepository _produtoRepo;
        private readonly IClienteRepository _clienteRepo;

        public PedidosController(
            IPedidoRepository pedidoRepo, IProdutoRepository produtoRepo,
            IClienteRepository clienteRepo
        )
        {
            _pedidoRepo = pedidoRepo;
            _produtoRepo = produtoRepo;
            _clienteRepo = clienteRepo;
        }

        public ActionResult Index()
        {
            var model = _pedidoRepo.Get();
            return View(model);
        }

        public ActionResult Adicionar() => View();

        public JsonResult GetClientesByName(string nome)
        {
            var data = _clienteRepo.GetByName(nome);
            return Json(data.Select(c=>new { c.Id, c.Nome }),
                JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _pedidoRepo.Dispose();
            _clienteRepo.Dispose();
            _produtoRepo.Dispose();
        }



    }
}
