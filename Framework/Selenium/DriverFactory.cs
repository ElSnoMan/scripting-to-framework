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
                    return new ChromeDriver();

                case "firefox":
                    return new FirefoxDriver();

                default:
                    throw new System.ArgumentException("Cannot build unsupported browser: " + browser);
            }
        }
    }
}
