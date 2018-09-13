using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fansoft.Store.Tests
{
    [TestClass]
    public class HelloWorldTest
    {
        [TestMethod]
        public void TestandoComOHelloWorld()
        {

            //Arrange (Ambiente)
            var flag = true;
            var random = new Random().Next(10);

            //Act (Ação)
            flag = random % 2 == 0;

            //Assert (Testa a execução)
            Assert.AreEqual(true, flag);

        }
    }
}
