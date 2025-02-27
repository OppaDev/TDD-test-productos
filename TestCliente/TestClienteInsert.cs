using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace TestCliente
{
    public class TestClienteInsert : IDisposable
    {
        private readonly IWebDriver driver;

        public TestClienteInsert()
        {
            driver = new FirefoxDriver();
        }

        [Fact]
        public void Create_Cliente_ReturnData()
        {
            driver.Navigate().GoToUrl("https://localhost:7159/Cliente/Create");

            driver.FindElement(By.Name("Cedula")).SendKeys("0402084040");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Nombre")).SendKeys("Juan");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Apellido")).SendKeys("Perez");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("FechaNacimiento")).SendKeys("2025-01-01T10:30");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Email")).SendKeys("sjose@mail.com");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Telefono")).SendKeys("0987654321");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Direccion")).SendKeys("Quito");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("Estado")).Click();
            Thread.Sleep(2000);

            driver.FindElement(By.Id("btnCrear")).Click();

            //assert
            Assert.Equal("https://localhost:7159/Cliente/Create", driver.Url);

        }

        public void Dispose()
        {
            driver?.Dispose();
        }


    }
}
