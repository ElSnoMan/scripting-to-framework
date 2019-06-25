using System;
using System.IO;
using System.Linq;
using Framework.Logging;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Framework
{
    public class FW
    {
        public static string WORKSPACE_DIRECTORY = Path.GetFullPath(@"../../../../");

        public static FwConfig Config => _configuration ?? throw new NullReferenceException("Config is null. Call FW.SetConfig() first.");

        public static Logger Log => _logger ?? throw new NullReferenceException("Logger is null. Call FW.SetLogger() first.");

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;

        [ThreadStatic]
        private static Logger _logger;

        private static FwConfig _configuration;

        public static DirectoryInfo CreateTestResultsDirectory()
        {
            var testResultsDirectory = WORKSPACE_DIRECTORY + "TestResults";

            if (Directory.Exists(testResultsDirectory))
            {
                Directory.Delete(testResultsDirectory, recursive: true);
            }

            return Directory.CreateDirectory(testResultsDirectory);
        }

        public static void SetConfig()
        {
            if (_configuration == null)
            {
                var jsonStr = File.ReadAllText(WORKSPACE_DIRECTORY + "/framework-config.json");
                _configuration = JsonConvert.DeserializeObject<FwConfig>(jsonStr);
            }
        }

        public static void SetLogger()
        {
            lock(_setLoggerLock)
            {
                var testResultsDirectory = WORKSPACE_DIRECTORY + "TestResults";
                var testName = TestContext.CurrentContext.Test.Name;
                var testPath = $"{testResultsDirectory}/{testName}";

                if (Directory.Exists(testPath))
                {
                    CurrentTestDirectory = Directory.CreateDirectory(testPath + TestContext.CurrentContext.Test.ID);
                }
                else
                {
                    CurrentTestDirectory = Directory.CreateDirectory(testPath);
                }

                _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
            }
        }

        private static object _setLoggerLock = new object();
    }
}
