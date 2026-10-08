using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //private IWebElement CreadoText => _driver.FindElement(By.Id("swal2-title"));
        private By CreadoText => By.Id("swal2-title");
        private List<IWebElement> botonesEditar => _driver.FindElements(By.ClassName("btnEditar")).ToList();
        private List<IWebElement> botonesEliminar => _driver.FindElements(By.ClassName("btnEliminar")).ToList();
        private IWebElement ConfirmDelete => _driver.FindElement(By.ClassName("swal2-confirm"));


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
        public void ClearContribuyenteForm()
        {
            wait.Until(driver => Nombre.Displayed);
            Nombre.Clear();
            ApellidoPaterno.Clear();
            ApellidoMaterno.Clear();
            Fecha.Clear();
        }

        public void ClickAddButton()
        {
            wait.Until(driver => CrearButton.Displayed);
            CrearButton.Click();
        }
        public string GetNombreSwal()
        {
            //wait.Until(driver => CreadoText.Displayed);
            //return CreadoText.Text;
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            var swal = wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(CreadoText);

                    return element.Displayed ? element : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });

            return swal.Text;
        }
        public string GetNombreModal()
        {
            wait.Until(driver => NombreTexto.Displayed);
            return NombreTexto.Text;
        }

        public void ClickLastEditarButton()
        {
            if (botonesEditar.Any())
            {
                botonesEditar.Last().Click();
            }
        }

        public void ClickLastEliminarButton()
        {
            if (botonesEliminar.Any())
            {
                botonesEliminar.Last().Click();
            }
        }

        public void ClickConfirmDelete()
        {
            wait.Until(driver => ConfirmDelete.Displayed);
            ConfirmDelete.Click();
        }
    }
}
