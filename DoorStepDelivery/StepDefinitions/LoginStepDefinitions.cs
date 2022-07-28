using DoorStepDelivery.Pages;
using System;
using TechTalk.SpecFlow;

namespace DoorStepDelivery.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPage _loginPage;

        public LoginStepDefinitions(LoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.GoTo();
            _loginPage.AcceptCookiePolicy();
        }

        [When(@"I enter invalid details and try to login")]
        public void WhenIEnterInvalidDetailsAndTryToLogin()
        {
            throw new PendingStepException();
        }

        [Then(@"I am not logged in")]
        public void ThenIAmNotLoggedIn()
        {
            throw new PendingStepException();
        }
    }
}
