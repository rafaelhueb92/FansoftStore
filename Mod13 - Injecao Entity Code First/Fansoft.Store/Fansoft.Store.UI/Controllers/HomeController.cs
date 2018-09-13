using System;
using System.Data.Common;
using System.Web.Mvc;

namespace Fansoft.Store.UI.Controllers
{
    public class HomeController:Controller
    {

        [HandleError(ExceptionType =typeof(Exception),View="Erro")]
        [HandleError(ExceptionType =typeof(DbException),View="ErroDeBanco")]
        public ActionResult Index()
        {
            //throw new Exception("Deu ruim");
            return View();
        }

        [Route("sobre")]
        public ActionResult About() => View();


        public ActionResult TestarErro()
        {
            throw new Exception("Deu ruim");
        }

    }
}
