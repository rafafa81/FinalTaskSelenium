using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace FinalTaskTests.driver
{
    internal class DriverSingleton
    {
        private static WebDriver? driver;

        private DriverSingleton() { }

        public static WebDriver GetDriver()
        {
            if (driver is null)
            {
                switch (Properties.Resources.browser)
                {
                    case "firefox":
                        new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                    case "edge":
                        new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                    default:
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
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
