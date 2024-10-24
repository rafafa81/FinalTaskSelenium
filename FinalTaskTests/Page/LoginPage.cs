using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using FinalTaskTests.Model;

namespace FinalTaskTests.Page
{
    public class LoginPage : AbstractPage
    {
        private readonly string usernameLocatorPath = "/html/body/div/div/div[2]/div[1]/div/div/form/div[1]/input";
        private readonly string passwordLocatorPath = "/html/body/div/div/div[2]/div[1]/div/div/form/div[2]/input";
        private readonly string loginButtonLocatorPath = "/html/body/div/div/div[2]/div[1]/div/div/form/input";
        public readonly string errorCardLocator = "/html/body/div/div/div[2]/div[1]/div/div/form/div[3]/h3";
        public WebDriverWait? wait;
        public readonly int SECONDS_TO_WAIT = 5;
        public IWebElement? inputUsername;
        public IWebElement? inputPassword;
        public IWebElement? loginButton;
        public string? errorMessage;

        
        public LoginPage(WebDriver driver) : base(driver)
        {
            
        }
        public override LoginPage OpenPage()
        {
            string urlPagina = @"https://saucedemo.com";
            driver.Navigate().GoToUrl(urlPagina);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(SECONDS_TO_WAIT));
            inputUsername = driver.FindElement(By.XPath(usernameLocatorPath));
            inputPassword = driver.FindElement(By.XPath(passwordLocatorPath));
            loginButton = driver.FindElement(By.XPath(loginButtonLocatorPath));
            errorMessage = string.Empty;
            return this;
        }

        public LoginPage Login()
        {
            Log.Debug("Initiating UC-1 test");
            if (inputUsername is not null && inputPassword is not null && loginButton is not null && wait is not null)
            {
                User tempUser = new User("Random","Random");
                inputUsername.Clear();
                inputPassword.Clear();
                inputUsername.SendKeys(tempUser.Username);
                inputPassword.SendKeys(tempUser.Password);
                Log.Debug("User and password filled");
                inputUsername.Clear();
                inputPassword.Clear();
                inputUsername.SendKeys(" ");
                inputPassword.Clear();
                inputPassword.SendKeys(" ");
                inputUsername.SendKeys(Keys.Backspace);
                inputPassword.SendKeys(Keys.Backspace);
                Log.Debug("User and password deleted");
                loginButton.Click();
                Log.Debug("Login button clicked");
                errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(errorCardLocator))).Text;
                
            }
            return this;
        }

        public LoginPage Login(string username)
        {
            Log.Debug("Initiating UC-2 test");
            if (inputUsername is not null && inputPassword is not null && loginButton is not null && wait is not null)
            {
                User tempUser = new User(username, "Random");
                inputUsername.Clear();
                inputPassword.Clear();
                inputUsername.SendKeys(tempUser.Username);
                inputPassword.SendKeys(tempUser.Password);
                Log.Debug("User and password filled");
                inputPassword.Clear();
                inputPassword.Clear();
                inputPassword.SendKeys(" ");
                inputPassword.SendKeys(Keys.Backspace);
                Log.Debug("Password deleted");
                loginButton.Click();
                Log.Debug("Login button clicked");
                errorMessage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(errorCardLocator))).Text;
            }
            return this;
        }

        public MainPage Login(User user)
        {
            Log.Information("Initiating UC-3 test");
            if (inputUsername is not null && inputPassword is not null && loginButton is not null && wait is not null)
            {
                inputUsername.SendKeys(user.Username);
                inputPassword.SendKeys(user.Password);
                Log.Debug("User and password filled");
                loginButton.Click();
                Log.Debug("Login button clicked");
            }
            return new MainPage(driver);
        }

        public string GetErrorMessage()
        {
            return errorMessage is null ? "Error" : errorMessage;
        }
    }
}
