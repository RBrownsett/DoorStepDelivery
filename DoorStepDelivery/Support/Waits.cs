using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DoorStepDelivery.Support
{
    public static class Waits
    {
        public static WebDriverWait Wait(this IWebDriver webDriver, int timeoutInMs = 10000, double pollingInterval = 0.5)
        {
            return new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(timeoutInMs))
            {
                PollingInterval = TimeSpan.FromSeconds(pollingInterval)
            };
        }

        public static void WaitUntilElementDisplayState(this IWebDriver webDriver, By by, bool elementDisplayState, int timeoutInMs = 10000, double pollingInterval = 0.5)
        {
            webDriver.Wait(timeoutInMs, pollingInterval).Until(x => x.FindElement(by).Displayed == elementDisplayState);
        }

        public static bool IsElementPresent(this IWebDriver webDriver, By by, bool elementDisplayState, int timeoutInMs = 10000, double pollingInterval = 0.5)
        {
            try
            {
                webDriver.WaitUntilElementDisplayState(by, elementDisplayState, timeoutInMs, pollingInterval);
            }
            catch(Exception ex)
            {
                if(ex is NoSuchElementException)
                {
                    return false;
                }
            }
            return true;
        }

        public static IWebElement ClickOn(this IWebDriver webDriver, By by, int timeoutInMs = 10000, double pollingInterval = 0.5)
        {
            return webDriver.Wait(timeoutInMs, pollingInterval).Until(driver =>
            {
                try
                {
                    IWebElement webElement = driver.FindElement(by);
                    if (webElement == null || !webElement.Displayed || !webElement.Enabled)
                    {
                        return null;
                    }
                    webElement.Click();
                    return webElement;
                }
                catch (Exception ex)
                {
                    if (ex is NoSuchElementException)
                    {
                        return null;
                    }
                    throw;
                }
            });
        }


        public static void WaitUntilElementInvisible(this IWebDriver webDriver, By by, int timeoutInMs = 10000, double pollingInterval = 0.5)
        {
            webDriver.Wait(timeoutInMs, pollingInterval).Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        public static IWebElement WaitForElement(this IWebDriver webDriver, By elementBy, int timeout = 10, double pollingInterval = 0.5)
        {
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeout))
            {
                PollingInterval = TimeSpan.FromSeconds(pollingInterval)
            };

            return webDriverWait.Until(driver =>
            {
                try
                {
                    IWebElement webElement = driver.FindElement(elementBy);
                    if (webElement != null && webElement.Displayed)
                    {
                        return webElement;
                    }

                    return null;
                }
                //Intentionally not using webDriverWait.IgnoreExceptionTypes as VS debugging still stops execution when thrown
                catch (Exception ex)
                {
                    if (ex is NoSuchElementException ||
                        ex is ElementNotVisibleException)
                    {
                        return null;
                    }

                    throw;
                }
            });
        }

    }
}
