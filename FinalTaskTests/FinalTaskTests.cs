using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Serilog;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace FinalTask.Tests
{
    [TestClass()]
    public class FinalTaskTests
    {
        public IWebDriver driver;
        public readonly string usernameLocatorPath = "/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input";
        public readonly string passwordLocatorPath = "/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input";
        public readonly string loginButtonLocatorPath = "/html/body/div/div/div[2]/div[1]/div/div/form/input";
        public readonly string errorCardLocator = "/html/body/div/div/div[2]/div[1]/div/div/form/div[3]/h3";
        public readonly string dashboardNameLocator = "/html/body/div/div/div/div[1]/div[1]/div[2]/div";
                 
        WebDriverWait wait;
        int SECONDS_TO_WAIT = 5;


        [TestInitialize]
        public void Init()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .CreateLogger();
            string urlPagina = @"https://saucedemo.com";
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            //driver = new ChromeDriver(path + @"\drivers\");
            //driver = new EdgeDriver(path + @"\drivers\");
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(urlPagina);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SECONDS_TO_WAIT));
        }

        [TestMethod("UC-1")]
        [DataRow("Random1", "Random1")]
        public void TaskMainTest1(string username, string password)
        {

            Log.Debug("Initiating UC-1 test");
            Actions builder = new Actions(driver);
            var inputUsername = driver.FindElement(By.XPath(usernameLocatorPath));
            var inputPassword = driver.FindElement(By.XPath(passwordLocatorPath));
            inputUsername.Clear();
            inputPassword.Clear();
            inputUsername.SendKeys("Random");
            inputPassword.SendKeys("Random");
            Log.Debug("User and password filled");
            inputUsername.Clear();
            inputPassword.Clear();
            inputUsername.SendKeys(" ");
            inputPassword.Clear();
            inputPassword.SendKeys(" ");
            inputUsername.SendKeys(Keys.Backspace);
            inputPassword.SendKeys(Keys.Backspace);
            Log.Debug("User and password deleted");
        
            var loginButton = driver.FindElement(By.XPath(loginButtonLocatorPath));
            
            loginButton.Click();
            Log.Debug("Login button clicked");
            var errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(errorCardLocator))).Text;
           
            
            Assert.AreEqual("Epic sadface: Username is required", errorMessage);
        }

        [TestMethod("UC-2")]
        [DataRow("Random2", "Random2")]
        public void TaskMainTest2(string username, string password)
        {
            
            Log.Debug("Initiating UC-2 test");

            Actions builder = new Actions(driver);
            var inputUsername = driver.FindElement(By.XPath(usernameLocatorPath));
            var inputPassword = driver.FindElement(By.XPath(passwordLocatorPath));
            inputUsername.Clear();
            inputPassword.Clear();
            inputUsername.SendKeys("Random");
            inputPassword.SendKeys("Random");
            Log.Debug("User and password filled");
            inputPassword.Clear();
            inputPassword.Clear();
            inputPassword.SendKeys(" ");
            inputPassword.SendKeys(Keys.Backspace);
            Log.Debug("Password deleted");
            var loginButton = driver.FindElement(By.XPath(loginButtonLocatorPath));
           
            loginButton.Click();
            Log.Debug("Login button clicked");
            var errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(errorCardLocator))).Text;
            
            
            Assert.AreEqual("Epic sadface: Password is required", errorMessage);
        }

        [TestMethod("UC-3")]
        [DataRow("standard_user", "secret_sauce")]
        public void TaskMainTest3(string username, string password)
        {
            
            Log.Information("Initiating UC-3 test");

            driver.FindElement(By.XPath(usernameLocatorPath)).SendKeys(username);
            driver.FindElement(By.XPath(passwordLocatorPath)).SendKeys(password);
            Log.Debug("User and password filled");
            driver.FindElement(By.XPath(loginButtonLocatorPath)).Click();
            Log.Debug("Login button clicked");
            var dashboardNameText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(dashboardNameLocator))).Text;
            
            Assert.AreEqual("Swag Labs", dashboardNameText);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close(); 
        }
    }
}