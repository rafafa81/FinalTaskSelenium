﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using FinalTaskTests.driver;
using FinalTaskTests.Page;
using FinalTaskTests.Model;

namespace FinalTaskTests.Tests
{
    [TestClass()]
    public class FinalTaskTests : CommonConditions
    {


        [TestMethod("UC-1")]
        public void TaskMainTest1()
        {
            string errorMessage = string.Empty;
            if (driver is not null)
            {
                errorMessage = new LoginPage(driver)
                    .OpenPage()
                    .Login()
                    .GetErrorMessage();
                Log.Debug(errorMessage);
            }

            Assert.AreEqual("Epic sadface: Username is required", errorMessage);
        }

        [TestMethod("UC-2")]
        public void TaskMainTest2()
        {
            User user = new User(Properties.Resources.testsUser, "Random2");
            string errorMessage = string.Empty;
            if (driver is not null && user.Username is not null)
            {
                errorMessage = new LoginPage(driver)
                .OpenPage()
                .Login(user.Username)
                .GetErrorMessage();
                Log.Debug(errorMessage);
            }

            Assert.AreEqual("Epic sadface: Password is required", errorMessage);
        }

        [TestMethod("UC-3")]
        public void TaskMainTest3()
        {
            User user = new User(Properties.Resources.testsUser, Properties.Resources.testsPassword);
            string dashboardNameText = string.Empty;
            if (driver is not null)
            {
                dashboardNameText = new LoginPage(driver)
                .OpenPage()
                .Login(user)
                .GetTextDashboard();
                Log.Debug(dashboardNameText);
            }

            Assert.AreEqual("Swag Labs", dashboardNameText);
        }

        [TestMethod("Adapter Test")]
        public void TaskMainTest4()
        {
            string dashboardNameText = string.Empty;
            if (driver is not null)
            {
                MainPage mainPage = new MainPage(driver);
                mainPage.Login().OpenPage();
                dashboardNameText = mainPage.GetTextDashboard();
            }

            Assert.AreEqual("Swag Labs", dashboardNameText);
        }
    }
}