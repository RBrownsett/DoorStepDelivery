using DoorStepDelivery.Pages;
using DoorStepDelivery.Support;
using System;
using TechTalk.SpecFlow;

namespace DoorStepDelivery.StepDefinitions
{
    [Binding]
    public class ForgotPasswordStepDefinitions
    {
        private readonly LoginPage _loginPage;
        private readonly ForgotPasswordPage _forgotPasswordPage;

        public ForgotPasswordStepDefinitions(Driver driver)
        {
            _loginPage = new LoginPage(driver.Current);
            _forgotPasswordPage = new ForgotPasswordPage(driver.Current);
        }

        [When(@"I request the forgot password feature")]
        public void WhenIRequestTheForgotPasswordFeature()
        {
            _loginPage.ClickOnForgotPassword();
        }

        [Then(@"I can view the forgot password page")]
        public void ThenICanViewTheForgotPasswordPage()
        {
            _forgotPasswordPage.IsPageLoaded().Should().BeTrue();
        }
    }
}
