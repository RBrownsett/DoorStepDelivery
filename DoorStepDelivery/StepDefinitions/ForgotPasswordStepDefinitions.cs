using System;
using TechTalk.SpecFlow;

namespace DoorStepDelivery.StepDefinitions
{
    [Binding]
    public class ForgotPasswordStepDefinitions
    {
        [When(@"I request the forgot password feature")]
        public void WhenIRequestTheForgotPasswordFeature()
        {
            throw new PendingStepException();
        }

        [Then(@"I can view the forgot password page")]
        public void ThenICanViewTheForgotPasswordPage()
        {
            throw new PendingStepException();
        }
    }
}
