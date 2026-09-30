using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SAT.UI.Tests.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Run in headless mode
            options.AddArgument("--disable-gpu"); // Disable GPU acceleration
            options.AddArgument("--window-size=1920,1080"); // Set window size
            return new ChromeDriver(options);
        }

        public static IWebDriver CreateEdgeDriver()
        {
            var options = new OpenQA.Selenium.Edge.EdgeOptions();
            //options.AddArgument("--headless"); // Run in headless mode
            //options.AddArgument("--disable-gpu"); // Disable GPU acceleration
            options.AddArgument("--window-size=1920,1080"); // Set window size
            return new OpenQA.Selenium.Edge.EdgeDriver(options);
        }
    }
}
