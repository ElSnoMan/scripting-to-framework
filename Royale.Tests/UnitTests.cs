using System.IO;
using Framework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Tests
{
    public class UnitTests
    {
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
            Assert.That(FW.WORKSPACE_DIRECTORY.EndsWith("scripting-to-framework/"), FW.WORKSPACE_DIRECTORY);
        }

        [Test, Category("unit")]
        public void Test_results_directory_created()
        {
            FW.CreateTestResultsDirectory();
            Assert.That(Directory.Exists(FW.WORKSPACE_DIRECTORY + "/TestResults"));
        }

        [Test, Category("unit")]
        public void Set_logger()
        {
            FW.SetLogger();
            FW.Log.Info("Test Message");
            var file = File.ReadAllText(FW.CurrentTestDirectory + "/log.txt");
            Assert.That(FW.CurrentTestDirectory.FullName.EndsWith("Set_logger"));
            Assert.That(file.Contains("Test Message"));
        }

        static int[] numbers = { 1, 2, 3, 4, 5 };

        [Test, Parallelizable(ParallelScope.Children), Ignore("meant to fail")]
        [Category("unit")]
        [TestCaseSource("numbers")]
        public void NUnit_test(int number)
        {
            var workerId = TestContext.CurrentContext.Test.ID;
            Assert.AreEqual("", workerId);
        }
    }
}
