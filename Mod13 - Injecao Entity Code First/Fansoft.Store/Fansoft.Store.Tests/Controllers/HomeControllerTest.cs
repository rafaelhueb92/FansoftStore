using Fansoft.Store.UI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace Fansoft.Store.Tests.Controllers
{
    [TestClass]
    [TestCategory("Controllers")]
    public class HomeControllerTest
    {
        //dado o HomeController

        [TestMethod]
        public void DeveraRetornarAViewIndex()
        {
            //arrange
            var homeController = new HomeController();

            //act
            
            //(ViewResult) = se não for do tipo certo, dá uma exception
            //var result = (ViewResult)homeController.Index();
            
            //as = faz o cast e se não conseguir retorna nulo
            var result = homeController.Index() as ViewResult;



            //assert
            Assert.AreEqual(typeof(ViewResult), result.GetType());
        }
        
    }
}
