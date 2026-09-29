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
        }

        [Test]
        public void CrearContribuyente()
        {
            _driver.Navigate().GoToUrl("https://localhost:44356/");

            var contribuyentePage = new ContribuyentePage(_driver);

            contribuyentePage.ClickCrearButton();
            var nombreModal = contribuyentePage.GetNombreModal();

            Assert.That(nombreModal, Is.EqualTo("Crear Contribuyente"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}