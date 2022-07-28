﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DoorStepDelivery.Support
{
    public static class Waits
    {
        public static WebDriverWait Wait(this IWebDriver webDriver, int timeoutInMs = 10000)
        {
            return new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(timeoutInMs));
        }

        public static void WaitUntilElementDisplayState(this IWebDriver webDriver, By by, bool elementDisplayState, int timeoutInMs = 10000)
        {
            webDriver.Wait().Until(x => x.FindElement(by).Displayed == elementDisplayState);
        }
    }
}
