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

        public void ClickCrearButton()
        {
            NombreInput.Click();
        }

        public string GetNombreModal()
        {
            wait.Until(driver => NombreTexto.Displayed);
            return NombreTexto.Text;
        }
    }
}
