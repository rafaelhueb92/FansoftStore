using Fansoft.Store.Domain.Entities;
using Fansoft.Store.Domain.Enums;
using Fansoft.Store.Domain.Helpers;
using System.Collections.Generic;
using System.Data.Entity;

namespace Fansoft.Store.Data.EF
{
    class DbInitializer : CreateDatabaseIfNotExists<FanSoftStoreDataContext>
    {

        protected override void Seed(FanSoftStoreDataContext context)
        {
            var alimento = new TipoProduto() { Nome = "Alimento" };
            var higiene = new TipoProduto() { Nome = "Higiene" };

            var produtos = new List<Produto>()
            {
                new Produto() { Nome = "Picanha", TipoProduto = alimento,Valor = 90.99M},
                new Produto() { Nome = "Pasta de Dente Colgate", TipoProduto=higiene, Valor = 10.50M},
                new Produto() { Nome = "Iogurte Batavo", TipoProduto = alimento,Valor = 5.25M},
            };
            context.Produtos.AddRange(produtos);


            var admin = new Perfil() { Nome = "Admin" };
            var user = new Perfil() { Nome = "User" };

            context.Usuarios.AddRange(
                    new List<Usuario>() {
                        new Usuario()
                        {
                            Nome = "Fabiano Nalin",
                            Email = "fabiano.nalin@gmail.com",
                            Senha = "123456".Encrypt(),
                            Perfil = admin
                        },
                        new Usuario()
                        {
                            Nome = "Priscila Mitui",
                            Email = "priscila@gmail.com",
                            Senha = "789012".Encrypt(),
                            Perfil = user
                        },
                    }
                );


            context.Clientes.AddRange(new List<Cliente>() {

                new Cliente(){ Nome="José Maria da Silva", Sexo=Sexo.Masculino},
                new Cliente(){ Nome="Maria José da Silva", Sexo=Sexo.Feminino},
                new Cliente(){ Nome="Mariana Souza", Sexo=Sexo.Feminino},
                new Cliente(){ Nome="José Carlos da Silva", Sexo=Sexo.Masculino},
            });

            context.SaveChanges();
        }
    }
}
