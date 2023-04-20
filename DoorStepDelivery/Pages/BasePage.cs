using DoorStepDelivery.Support;
using OpenQA.Selenium;

namespace DoorStepDelivery.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _webDriver;
        private readonly By _acceptAllCookies = By.Id("cookiesscript_accept");
        private const string _cookiePolicyId = "cookiescript_injected";

        private IWebElement CookiesAcceptButton => _webDriver.FindElement(By.Id("cookiescript_accept"));

        public BasePage(IWebDriver driver)
        {
            _webDriver = driver;
        }

        public void AcceptCookies()
        {
            _webDriver.WaitUntilElementDisplayState(By.Id(_cookiePolicyId), true);
            CookiesAcceptButton.Click();
        }

        public void AcceptCookiePolicy()
        {
            _webDriver.WaitUntilElementDisplayState(By.Id(_cookiePolicyId), true);
            CookiesAcceptButton.Click();
            _webDriver.WaitUntilElementDisplayState(By.Id(_cookiePolicyId), false);
        }

    }
}
