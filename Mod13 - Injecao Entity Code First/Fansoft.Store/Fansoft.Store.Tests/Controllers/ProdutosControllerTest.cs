using Fansoft.Store.Domain.Contracts;
using Fansoft.Store.Domain.Entities;
using Fansoft.Store.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Fansoft.Store.Tests.Controllers
{
    [TestClass]
    public class ProdutosControllerTest
    {

        //dado um produtosController

        [TestMethod]
        [TestCategory("Controllers")]
        public void AoExecutarOMetodoIndexDeveraRetornarAViewComOModeloCorreto()
        {
            //a
            var produtosController = 
                new ProdutosController(new ProdutoRepositoryFake(), new TipoProdRepositoryFake());

            //a
            var result = produtosController.Index() as ViewResult;
            var model = result.Model as List<Produto>;

            //a
            Assert.AreEqual(typeof(ViewResult), result.GetType());
            Assert.AreEqual(3, model.Count);
        }
    }

    //Pode ser usado o Moq (https://github.com/fnalin/CadCli-Api/blob/master/CadCli.Tests/Dominio/Repositorio/IClienteRepositorioTest.cs)
    class ProdutoRepositoryFake : IProdutoRepository
    {
        public Produto Add(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Produto Get(object pk)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Get()
        {
            var alimento = new TipoProduto() { Nome = "Alimento" };
            var higiene = new TipoProduto() { Nome = "Higiene" };

            var produtos = new List<Produto>()
            {
                new Produto() { Nome = "Picanha", TipoProduto = alimento,Valor = 90.99M},
                new Produto() { Nome = "Pasta de Dente Colgate", TipoProduto=higiene, Valor = 10.50M},
                new Produto() { Nome = "Iogurte Batavo", TipoProduto = alimento,Valor = 5.25M},
            };

            return produtos;
        }

        public void Update(Produto entity)
        {
            throw new NotImplementedException();
        }
    }
    class TipoProdRepositoryFake : ITipoProdutoRepository
    {
        public TipoProduto Add(TipoProduto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TipoProduto entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public TipoProduto Get(object pk)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoProduto> Get()
        {
            throw new NotImplementedException();
        }

        public void Update(TipoProduto entity)
        {
            throw new NotImplementedException();
        }
    }
}
