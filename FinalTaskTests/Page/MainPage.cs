﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTaskTests.Page
{
    internal class MainPage : AbstractPage
    {
        public readonly string dashboardNameLocator = "/html/body/div/div/div/div[1]/div[1]/div[2]/div";
        public string dashboardNameText = string.Empty;
        public WebDriverWait? wait;
        public readonly int SECONDS_TO_WAIT = 5;

        public MainPage(WebDriver driver) : base(driver) { }

        public override MainPage OpenPage()
        {
            string urlPagina = @"https://www.saucedemo.com/inventory.html";
            driver.Navigate().GoToUrl(urlPagina);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT_SECONDS));
            return this;
        }

        public string GetTextDashboard()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_TIMEOUT_SECONDS));
            dashboardNameText = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(dashboardNameLocator))).Text;
            return dashboardNameText;
        }
    }
}