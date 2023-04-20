using System.IO;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace DoorStepDelivery.Support.LoggingHooks
{
    [Binding]
    public class LoggingHooks
    {
        private readonly Driver _browserDriver;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public LoggingHooks(Driver browserDriver, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _browserDriver = browserDriver;
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [AfterStep()]
        public void TakeScreenshotAfterEachStep()
        {

            if (_browserDriver.Current is ITakesScreenshot screenshotTaker)
            {
                //var filename = Path.ChangeExtension(Path.GetRandomFileName(), "png");

                string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0", "\\") + "Screenshot\\";
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                path = path + Guid.NewGuid() + ".png";

                screenshotTaker.GetScreenshot().SaveAsFile(path);

                _specFlowOutputHelper.AddAttachment(path);
            }
        }
    }
}