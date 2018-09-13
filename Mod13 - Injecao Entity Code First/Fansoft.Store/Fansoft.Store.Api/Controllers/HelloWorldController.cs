using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace Fansoft.Store.Api.Controllers
{
    public class HelloWorldController:ApiController
    {

        //GET => Geralmente é utilizado para obter informação

        public string Get()
        {
            return "Vc bateu no Get do HelloWorldController";
        }


        public string Get(int id)
        {
            return $"Vc bateu no Get do HelloWorldController - {id}";
        }

        //POST => Utilizado só para adicionar um recurso

        public string Post(HelloWorldModel model)
        {
            return $"{model.Id} - {model.Nome}";
        }

        //PUT => Utilizado para alterar um recurso
        //PATCH => Atualizar parcial

        public string Put(int id, HelloWorldModel model)
        {
            return $"{id} - {model.Id} - {model.Nome}";
        }

        //Delete => Para excluir recurso
        public string Delete(int id)
        {
            return $"Vc bateu no Delete do HelloWorldController - {id}";
        }


    }

    public class HelloWorldModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

}
