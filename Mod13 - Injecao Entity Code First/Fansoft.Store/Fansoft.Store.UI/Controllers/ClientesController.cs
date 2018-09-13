using Fansoft.Store.Domain.Contracts;
using Fansoft.Store.Domain.Entities;
using Fansoft.Store.UI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fansoft.Store.UI.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepo;
        public ClientesController(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public ActionResult Index()
        {
            var model = _clienteRepo.Get();
            return View(model);
        }

        [AuthorizeUsers("Admin")]
        public ActionResult AddEdit(int? id)
        {
            Cliente model;

            if (id == null)
            {
                model = new Cliente();
            }
            else
            {
                model = _clienteRepo.Get(id);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddEdit(Cliente model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.Id == 0)
                    {
                        _clienteRepo.Add(model);
                    }
                    else
                    {
                        _clienteRepo.Update(model);
                    }

                    //throw new Exception("Erro no banco");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }

            return View(model);
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            var success = false;
            var msg = "Cliente não localizado";
            var item = _clienteRepo.Get(id);
            if (item != null)
            {
                _clienteRepo.Delete(item);
                success = true;
                msg = "Cliente excluído";
            }

            return Json(new { success, msg });
        }

        protected override void Dispose(bool disposing)
        {
            _clienteRepo.Dispose();
        }

    }
}
