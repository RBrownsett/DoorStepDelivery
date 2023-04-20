using DoorStepDelivery.Pages;
using DoorStepDelivery.Support;
using System;
using TechTalk.SpecFlow;

namespace DoorStepDelivery.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPage _loginPage;

        public LoginStepDefinitions(Driver driver)
        {
            _loginPage = new LoginPage(driver.Current);
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.GoTo();
            _loginPage.AcceptCookies();
        }

        [When(@"I enter invalid details and try to login")]
        public void WhenIEnterInvalidDetailsAndTryToLogin()
        {
            _loginPage.Login("1234", "ABCDEFG");
        }

        [Then(@"I am not logged in")]
        public void ThenIAmNotLoggedIn()
        {
            _loginPage.IsPageLoaded().Should().BeTrue();
        }

        [Then(@"the page title is displayed")]
        public void ThenThePageTitleIsDisplayed()
        {
            _loginPage.GetPageTitle().Should().Be("Account");
        }

    }
}
