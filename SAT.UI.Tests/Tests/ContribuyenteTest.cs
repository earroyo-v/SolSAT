using NUnit.Framework;
using OpenQA.Selenium;
using SAT.UI.Tests.Drivers;
using SAT.UI.Tests.Pages;

namespace SAT.UI.Tests.Tests
{
    public class ContribuyenteTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = DriverFactory.CreateEdgeDriver();
            _driver.Navigate().GoToUrl("http://localhost:8081/");
            //_driver.Navigate().GoToUrl("https://localhost:44356/");
        }

        [Test]
        public void CrearContribuyente()
        {
            var contribuyentePage = new ContribuyentePage(_driver);

            contribuyentePage.WaitForLoaderToDisappear();
            contribuyentePage.ClickCrearButton();
            contribuyentePage.FillContribuyenteForm("Juan", "Pérez", "García", "19-01-2001");
            contribuyentePage.ClickAddButton();

            var nombreModal = contribuyentePage.GetNombreSwal();

            Assert.That(nombreModal, Is.EqualTo("¡Contribuyenete Creado!"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}