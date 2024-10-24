using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTaskTests.driver;
using Serilog;

namespace FinalTaskTests.Tests
{
    
    public class CommonConditions
    {
        public IWebDriver? driver;
        private readonly string usernameLocatorPath = "/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input";
        private readonly string passwordLocatorPath = "/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input";
        private readonly string loginButtonLocatorPath = "/html/body/div/div/div[2]/div[1]/div/div/form/input";
        public readonly string errorCardLocator = "/html/body/div/div/div[2]/div[1]/div/div/form/div[3]/h3";
        public readonly string dashboardNameLocator = "/html/body/div/div/div/div[1]/div[1]/div[2]/div";

        public WebDriverWait? wait;
        public readonly int SECONDS_TO_WAIT = 5;
        public IWebElement? inputUsername;
        public IWebElement? inputPassword;
        public IWebElement? loginButton;
        public string? errorMessage;

        [TestInitialize]
        public void Init()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .CreateLogger();
            string urlPagina = @"https://saucedemo.com";
            driver = DriverSingleton.GetDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(urlPagina);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SECONDS_TO_WAIT));
            inputUsername = driver.FindElement(By.XPath(usernameLocatorPath));
            inputPassword = driver.FindElement(By.XPath(passwordLocatorPath));
            loginButton = driver.FindElement(By.XPath(loginButtonLocatorPath));
            errorMessage = string.Empty;
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (driver is not null)
            {
                DriverSingleton.closeDriver();
            }
        }
    }
}
