using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestCliente
{

    public class TestClienteDelete : IDisposable
    {
        private readonly IWebDriver driver;
        
        public TestClienteDelete()
        {
            driver = new FirefoxDriver();
        }
        [Fact]
        public void Delete_Cliente_ReturnData()
        {
            driver.Navigate().GoToUrl("https://localhost:7159/Cliente");
            var deleteLink = driver.FindElement(By.CssSelector("a[href='/Cliente/Delete/2']"));
            Thread.Sleep(2000);
            deleteLink.Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("btnEliminar")).Click();
            Thread.Sleep(2000);
            //assert
            Assert.Equal("https://localhost:7159/Cliente", driver.Url);
        }
        public void Dispose()
        {
            driver?.Dispose();
        }
    }
}
