using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SAT.UI.Tests.Pages
{
    public class ContribuyentePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait wait;

        public ContribuyentePage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement NombreInput => _driver.FindElement(By.ClassName("btnCrear"));
        private IWebElement NombreTexto => _driver.FindElement(By.ClassName("modal-title"));
        private IWebElement Loader => _driver.FindElement(By.Id("loading"));
        private IWebElement Nombre => _driver.FindElement(By.Id("Nombre"));
        private IWebElement ApellidoPaterno => _driver.FindElement(By.Id("ApellidoPaterno"));
        private IWebElement ApellidoMaterno => _driver.FindElement(By.Id("ApellidoMaterno"));
        private IWebElement Fecha => _driver.FindElement(By.Id("FechaNacimiento"));
        private IWebElement CrearButton => _driver.FindElement(By.Id("btnAdd"));
        private IWebElement CreadoText => _driver.FindElement(By.Id("swal2-title"));

        public void WaitForLoaderToDisappear()
        {
            wait.Until(driver => !Loader.Displayed);
        }

        public void ClickCrearButton()
        {
            var button = wait.Until(driver => NombreInput.Displayed ? NombreInput : null);
            button.Click();
        }

        public void FillContribuyenteForm(string nombre, string apellidoPaterno, string apellidoMaterno, string fechaNacimiento)
        {
            wait.Until(driver => Nombre.Displayed);
            Nombre.SendKeys(nombre);
            ApellidoPaterno.SendKeys(apellidoPaterno);
            ApellidoMaterno.SendKeys(apellidoMaterno);
            Fecha.SendKeys(fechaNacimiento);
        }

        public void ClickAddButton()
        {
            wait.Until(driver => CrearButton.Displayed);
            CrearButton.Click();
        }
        public string GetNombreSwal()
        {
            wait.Until(driver => CreadoText.Displayed);
            return CreadoText.Text;
        }
        public string GetNombreModal()
        {
            wait.Until(driver => NombreTexto.Displayed);
            return NombreTexto.Text;
        }
    }
}
