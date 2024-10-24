using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace FinalTaskTests.Page
{
    public abstract class AbstractPage
    {
        protected WebDriver driver;
        public abstract AbstractPage OpenPage();
        protected const int WAIT_TIMEOUT_SECONDS = 20;
        

        public AbstractPage(WebDriver driver)
        {
            this.driver = driver;
        }
    }
}
