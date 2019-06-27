using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.Selenium
{
    public static class DriverFactory
    {
        public static IWebDriver Build(string browser)
        {
            FW.Log.Info("Open browser: " + browser);

            switch (browser)
            {
                case "chrome":
                    return BuildChrome();

                case "firefox":
                    return new FirefoxDriver();

                default:
                    throw new System.ArgumentException("Cannot build unsupported browser: " + browser);
            }
        }

        private static ChromeDriver BuildChrome()
        {
            var options = new ChromeOptions();
            // options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
