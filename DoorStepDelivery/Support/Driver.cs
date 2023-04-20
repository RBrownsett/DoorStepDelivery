using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using TechTalk.SpecFlow.Infrastructure;
using OpenQA.Selenium.DevTools.V101.Target;

namespace DoorStepDelivery.Support
{
    public class Driver : IDisposable
    {
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        public Driver(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        /// <summary>
        /// The Selenium IWebDriver instance
        /// </summary>
        public IWebDriver Current => _currentWebDriverLazy.Value;

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateWebDriver()
        {
            //We use the Chrome browser
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();

            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);

            _specFlowOutputHelper.WriteLine("Browser launched");

            return chromeDriver;
        }

        /// <summary>
        /// Disposes the Selenium web driver (closing the browser)
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();

                _specFlowOutputHelper.WriteLine("Browser closed");
            }

            _isDisposed = true;
        }
    }
}