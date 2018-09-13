using Fansoft.Store.Api.Models;
using Fansoft.Store.Domain.Contracts;
using Fansoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Fansoft.Store.Api.Controllers
{
    
    [RoutePrefix("api/v1/produtos")]
    public class ProdutosController:ApiController
    {
        private readonly IProdutoRepository _prodRepo;
        public ProdutosController(IProdutoRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        [Route]
        public IEnumerable<ProdutoVM> Get()
        {
            return _prodRepo.Get().Select(p => new ProdutoVM{
                Id = p.Id,
                Nome = p.Nome,
                Valor = p.Valor,
                TipoProdutoId = p.TipoProdutoId,
                TipoProdutoNome = p.TipoProduto.Nome
            });
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var data = _prodRepo.Get(id);

            if (data==null)
                return NotFound();

            return Ok(new ProdutoVM() {
                Id = data.Id,
                Nome = data.Nome,
                Valor = data.Valor,
                TipoProdutoId = data.TipoProdutoId,
                TipoProdutoNome = data.TipoProduto.Nome
            });
        }


        [Route]
        public IHttpActionResult Post(ProdutoVM model)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto()
                {
                    Nome = model.Nome,
                    Valor = model.Valor,
                    TipoProdutoId = model.TipoProdutoId
                };

                _prodRepo.Add(produto);

                var location = $"{Request.RequestUri}/{produto.Id}";
                return Created(location, produto);
            }

            return BadRequest(ModelState);
        }

        [Route("{id}")]
        public IHttpActionResult Put(int id, ProdutoVM model)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto()
                {
                    Id = id,
                    Nome = model.Nome,
                    Valor = model.Valor,
                    TipoProdutoId = model.TipoProdutoId
                };
                _prodRepo.Update(produto);
                return Ok();
            }

            return BadRequest(ModelState);
        }


        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var data = _prodRepo.Get(id);

            if (data == null)
                return NotFound();

            _prodRepo.Delete(data);

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            _prodRepo.Dispose();
        }

    }
}
