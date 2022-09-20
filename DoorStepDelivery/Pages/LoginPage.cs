using DoorStepDelivery.Support;
using OpenQA.Selenium;

namespace DoorStepDelivery.Pages
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver _webDriver;

        private const string _loginPageUrl = "https://themodernmilkman.co.uk/Users/login";
        private const string _phoneNumberInputField = "phoneNo";
        private const string _passwordIinputField = "password";
        public const string _loginButtonId = "checkLogin";


        private IWebElement LoginButton => _webDriver.FindElement(By.Id(_loginButtonId));
        internal IWebElement PhoneNumberInputField => _webDriver.FindElement(By.Id(_phoneNumberInputField));
        internal IWebElement PasswordInputField => _webDriver.FindElement(By.Id(_passwordIinputField));

        private By _forgotPasswordText = By.LinkText("Forgot Password?");
       
        public LoginPage(Driver driver) : base(driver)
        {
            _webDriver = driver.WebDriver;
        }

        public void GoTo() => _webDriver.Navigate().GoToUrl(_loginPageUrl);

        public void Login(string mobileNumber, string password)
        {
            PhoneNumberInputField.SendKeys(mobileNumber);
            PasswordInputField.SendKeys(password);
            LoginButton.Click();
        }
        public bool IsPageLoaded(int maxPageLoadTimeSeconds = 20)
        {
            var isPhoneNumberElementPresent = _webDriver.IsElementPresent(By.Id(_phoneNumberInputField), true, maxPageLoadTimeSeconds);
            var isUrlCorrect = _webDriver.Url.Equals(_loginPageUrl);
            return isUrlCorrect && isPhoneNumberElementPresent;
        }

        public void ClickOnForgotPassword()
        {
            var fortgotPasswordLink = _webDriver.FindElement(_forgotPasswordText);
            _webDriver.ClickOn(_forgotPasswordText);
        }
    }
}
