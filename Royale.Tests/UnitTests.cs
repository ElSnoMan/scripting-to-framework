using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Tests
{
    public class UnitTests
    {
        string ROOT_PATH = Path.GetFullPath(@"../../../../");

        [OneTimeSetUp]
        public void BeforeAll()
        {
        }

        [SetUp]
        public void BeforeEach()
        {
        }

        [TearDown]
        public void AfterEach()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace;
            var message = TestContext.CurrentContext.Result.Message;

            if (status == TestStatus.Failed)
            {
            }
            else if (status == TestStatus.Passed)
            {
            }
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
        }

        [Test, Category("unit")]
        public void Get_workspace_path()
        {
            Assert.That(ROOT_PATH.EndsWith("scripting-to-framework/"), ROOT_PATH);
        }
    }
}
