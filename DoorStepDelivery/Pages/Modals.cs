using DoorStepDelivery.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorStepDelivery.Pages
{
    public class Modals : BasePage
    {
        private readonly IWebDriver _webDriver;

        private By _invalidLoginTextElement = By.Id("swal2-content");
        public Modals(Driver driver) : base(driver)
        {
            _webDriver = driver.WebDriver;
        }

        private string GetInvalidLoginText()
        {
            _webDriver.WaitUntilElementDisplayState(_invalidLoginTextElement, true);
            var invalidLoginText = _webDriver.FindElement(_invalidLoginTextElement).Text;
            return invalidLoginText;
        }
    }
}
