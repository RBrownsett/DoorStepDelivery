using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorStepDelivery.Support
{
    public class Driver : IDisposable
    {
        public IWebDriver WebDriver;

        public Driver()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void Dispose()
        {
            WebDriver.Dispose();
        }
    }
}
