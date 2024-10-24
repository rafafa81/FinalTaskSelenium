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
        public WebDriver? driver;

        [TestInitialize]
        public void Init()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .MinimumLevel.Debug()
            .CreateLogger();
            driver = DriverSingleton.GetDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
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
