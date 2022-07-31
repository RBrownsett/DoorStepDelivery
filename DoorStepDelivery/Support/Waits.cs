﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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


    }
}
