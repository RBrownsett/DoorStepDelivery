using DoorStepDelivery.Support;
using OpenQA.Selenium;

namespace DoorStepDelivery.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _webDriver;

        private const string _cookiePolicyId = "cookiescript_injected";
        private const string _loginPageUrl = "https://themodernmilkman.co.uk/";

        private IWebElement CookiesAcceptButton => _webDriver.FindElement(By.Id("cookiescript_accept"));
        public LoginPage(Driver driver)
        {
            _webDriver = driver.WebDriver;
        }

        public void AcceptCookiePolicy()
        {
            _webDriver.WaitUntilElementDisplayState(By.Id(_cookiePolicyId), true);
            CookiesAcceptButton.Click();
            _webDriver.WaitUntilElementDisplayState(By.Id(_cookiePolicyId), false);

        }

        public void GoTo() => _webDriver.Navigate().GoToUrl(_loginPageUrl);
    }
}
