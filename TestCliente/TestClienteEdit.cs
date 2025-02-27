using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace TestCliente
{
    public class TestClienteEdit : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        public TestClienteEdit()
        {
            driver = new FirefoxDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        [Fact]
        public void Edit_Cliente_ReturnData()
        {
            driver.Navigate().GoToUrl("https://localhost:7159/Cliente");

            var editLink = wait.Until(d => d.FindElement(By.CssSelector("a[href='/Cliente/Edit/2']")));
            editLink.Click();


            
            driver.FindElement(By.Name("Nombre")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Nombre")).SendKeys("Juan");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("Apellido")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Apellido")).SendKeys("Perez");
            Thread.Sleep(2000);
            
            driver.FindElement(By.Name("Email")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Email")).SendKeys("sjose@mail.com");
            Thread.Sleep(2000);

            
            driver.FindElement(By.Name("Direccion")).Clear();
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Direccion")).SendKeys("Montufar");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("Estado")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("btnEditar")).Click();

            //assert
            Assert.Equal("https://localhost:7159/Cliente/Edit/2", driver.Url);
        }
        public void Dispose()
        {
            driver?.Dispose();
        }
    }
}
