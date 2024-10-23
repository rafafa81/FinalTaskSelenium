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
        

        [TestMethod()]
        [DataRow("Random1", "Random1")]
        public void TaskMainTest1(string username, string password)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
            Log.Information("Hello, world!");
            string urlPagina = @"https://saucedemo.com";
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(urlPagina);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SECONDS_TO_WAIT));
            Actions builder = new Actions(driver);
            var inputUsername = driver.FindElement(By.XPath(usernameLocatorPath));
            var inputPassword = driver.FindElement(By.XPath(passwordLocatorPath));
            inputUsername.Clear();
            inputPassword.Clear();
            inputUsername.SendKeys("Random");
            inputPassword.SendKeys("Random");
            inputUsername.Clear();
            inputPassword.Clear();
            inputUsername.SendKeys(" ");
            inputPassword.Clear();
            inputPassword.SendKeys(" ");
            inputUsername.SendKeys(Keys.Backspace);
            inputPassword.SendKeys(Keys.Backspace);
            Log.Information(inputUsername.Text);
            Log.Information(inputPassword.Text);
            var loginButton = driver.FindElement(By.XPath(loginButtonLocatorPath));
            Thread.Sleep(2000);
            loginButton.Click();
            var errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(errorCardLocator))).Text;
            Thread.Sleep(4000);
            driver.Close();
            Assert.AreEqual("Epic sadface: Username is required", errorMessage);
        }

        [TestMethod()]
        [DataRow("Random2", "Random2")]
        public void TaskMainTest2(string username, string password)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
            Log.Information("Hello, world!");
            string urlPagina = @"https://saucedemo.com";
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(urlPagina);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SECONDS_TO_WAIT));
            Actions builder = new Actions(driver);
            var inputUsername = driver.FindElement(By.XPath(usernameLocatorPath));
            var inputPassword = driver.FindElement(By.XPath(passwordLocatorPath));
            inputUsername.Clear();
            inputPassword.Clear();
            inputUsername.SendKeys("Random");
            inputPassword.SendKeys("Random");
            inputPassword.Clear();
            inputPassword.Clear();
            inputPassword.SendKeys(" ");
            inputPassword.SendKeys(Keys.Backspace);
            Log.Information(inputUsername.Text);
            Log.Information(inputPassword.Text);
            var loginButton = driver.FindElement(By.XPath(loginButtonLocatorPath));
            Thread.Sleep(2000);
            loginButton.Click();
            var errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(errorCardLocator))).Text;
            Thread.Sleep(4000);
            driver.Close();
            Assert.AreEqual("Epic sadface: Password is required", errorMessage);
        }

        [TestMethod()]
        [DataRow("standard_user", "secret_sauce")]
        public void TaskMainTest3(string username, string password)
        {
            string urlPagina = @"https://saucedemo.com";
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.Navigate().GoToUrl(urlPagina);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SECONDS_TO_WAIT));
            driver.FindElement(By.XPath(usernameLocatorPath)).SendKeys(username);
            driver.FindElement(By.XPath(passwordLocatorPath)).SendKeys(password);
            driver.FindElement(By.XPath(loginButtonLocatorPath)).Click();
            Thread.Sleep(4000);
            var dashboardNameText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(dashboardNameLocator))).Text;
            driver.Close();
            Assert.AreEqual("Swag Labs", dashboardNameText);
        }

        
    }
}