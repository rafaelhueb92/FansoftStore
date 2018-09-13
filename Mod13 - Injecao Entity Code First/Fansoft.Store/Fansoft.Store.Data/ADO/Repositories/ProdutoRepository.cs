using Fansoft.Store.Domain.Contracts;
using Fansoft.Store.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Fansoft.Store.Data.ADO.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly FanSoftStoreDataContext _ctx =
            new FanSoftStoreDataContext();

        public Produto Add(Produto entity)
        {
            var sql = $"INSERT INTO Produto " +
                $"(NomeDoProduto, TipoProdutoId, Valor, DataCadastro) Values('{entity.Nome}',{entity.TipoProdutoId}," +
                $"{entity.Valor},'{entity.DataCadastro}')";
            _ctx.ExecuteCMD(sql);
            return entity;
        }

        public void Delete(Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public Produto Get(object pk)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> Get()
        {
            var query = @"SELECT p.Id, p.NomeDoProduto, p.Valor, tp.Nome as TipoProduto 
                                FROM  PRODUTO p
	                    INNER JOIN TipoProduto tp ON p.TipoProdutoId = tp.Id";
            var data = _ctx.ExecuteCommandWithReturn(query);
            var produtos = new List<Produto>();
            while (data.Read())
            {
                produtos.Add(new Produto() {
                    Id = int.Parse(data["Id"].ToString()),
                    Nome = data["NomeDoProduto"].ToString(),
                    Valor = decimal.Parse(data["Valor"].ToString()),
                    TipoProduto = new TipoProduto() {
                        Nome = data["TipoProduto"].ToString()
                    }
                });
            }

            return produtos;

        }

        public void Update(Produto entity)
        {
            throw new NotImplementedException();
        }
    }
}
