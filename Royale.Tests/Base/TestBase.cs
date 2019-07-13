using Framework;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Royale.Pages;

namespace Tests.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Init();
            Driver.Goto(FW.Config.Test.Url);
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if (outcome == TestStatus.Passed)
            {

            }
            else if (outcome == TestStatus.Failed)
            {
                Driver.TakeScreenshot("test_failed");
            }
            else
            {

            }

            FW.Log.Info("Outcome: " + outcome);

            Driver.Quit();
        }
    }
}
