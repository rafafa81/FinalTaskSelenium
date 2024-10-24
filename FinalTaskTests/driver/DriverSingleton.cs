using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTaskTests.driver
{
    internal class DriverSingleton
    {
        private static readonly string RESOURCE_PATH = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private static WebDriver? driver;

        private DriverSingleton() { }

        public static WebDriver GetDriver()
        {
            if (driver is null)
            {
                switch (Properties.Resources.browser)
                {
                    case "firefox":
                        driver = new FirefoxDriver();
                        break;
                    case "edge":
                        driver = new EdgeDriver(RESOURCE_PATH + @"\drivers\");
                        break;
                    default:
                        driver = new ChromeDriver(RESOURCE_PATH + @"\drivers\");
                        break;
                }
            }
            return driver;
        }

        public static void closeDriver()
        {
            if (driver is not null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
