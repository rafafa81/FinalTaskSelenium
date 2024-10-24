using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTaskTests.Model;
using FinalTaskTests.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalTaskTests.Adapter
{
    public class LoginAdapter
    {
        public LoginPage loginPage;
        public LoginAdapter(WebDriver driver)
        {
            loginPage = new LoginPage(driver);
        }

        public MainPage Login(User user)
        {

            return loginPage.OpenPage().Login(user);
        }
    }
}
