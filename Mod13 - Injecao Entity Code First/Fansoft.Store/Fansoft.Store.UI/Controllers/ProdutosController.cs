using Fansoft.Store.Data.EF;
using Fansoft.Store.Data.EF.Repositories;
using Fansoft.Store.Domain.Contracts;
using Fansoft.Store.Domain.Entities;
using Fansoft.Store.UI.Filters;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Fansoft.Store.UI.Controllers
{
    [AuthorizeUsers("Admin,User")]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRep;

        private readonly ITipoProdutoRepository _tipoProdRep;

        //public ProdutosController()
        //{
        //    _produtoRep = new ProdutoRepository();
        //    _tipoProdRep = new TipoProdutoRepository();
        //}

        public ProdutosController(
            IProdutoRepository produtoRep, ITipoProdutoRepository tipoProdutoRep)
        {
            _produtoRep = produtoRep;
            _tipoProdRep = tipoProdutoRep;
        }



        public ActionResult Index()
        {
            var produtos = _produtoRep.Get();
            return View(produtos);
        }

        [AuthorizeUsers("Admin")]
        public ActionResult AddEdit(int? id)
        {
            Produto model;

            if (id == null)
            {
                model = new Produto();
            }
            else
            {
                model = _produtoRep.Get(id);
            }

            ViewBag.TipoProdutos = _tipoProdRep.Get();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEdit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (produto.Id == 0)
                    {
                        _produtoRep.Add(produto);
                    }
                    else
                    {
                        _produtoRep.Update(produto);
                    }

                    //throw new Exception("Erro no banco");
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }

            }

            ViewBag.TipoProdutos = _tipoProdRep.Get();
            return View(produto);
        }

        [HttpPost]
        public JsonResult Excluir(int id)
        {
            var success = false;
            var msg = "produto não localizado";
            var produto = _produtoRep.Get(id);
            if (produto != null)
            {
                _produtoRep.Delete(produto);
                success = true;
                msg = "Produto excluído";
            }

            return Json(new { success, msg });
        }


        protected override void Dispose(bool disposing)
        {
            _tipoProdRep.Dispose();
            _produtoRep.Dispose();
        }

    }
}
