using DoorStepDelivery.Pages;
using System;
using TechTalk.SpecFlow;

namespace DoorStepDelivery.StepDefinitions
{
    [Binding]
    public class ForgotPasswordStepDefinitions
    {
        private readonly LoginPage _loginPage;

        public ForgotPasswordStepDefinitions(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [When(@"I request the forgot password feature")]
        public void WhenIRequestTheForgotPasswordFeature()
        {
            _loginPage.ClickOnForgotPassword();
        }

        [Then(@"I can view the forgot password page")]
        public void ThenICanViewTheForgotPasswordPage()
        {
            throw new PendingStepException();
        }
    }
}
