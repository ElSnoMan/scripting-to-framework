using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Selenium
{
    public class Driver
    {
        [ThreadStatic]
        static IWebDriver _driver;

        [ThreadStatic]
        public static Wait Wait;

        public static void Init(int waitSeconds = 10)
        {
            FW.Log.Info("Open browser: Chrome");
            _driver = new ChromeDriver();
            Wait = new Wait(waitSeconds);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null. Call Driver.Init() first.");

        public static string Title => Current.Title;

        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            FW.Log.Step($"Navigate to {url}");
            Current.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public static void Quit()
        {
            FW.Log.Info("Close browser");
            Current.Quit();
            Current.Dispose();
        }
    }
}
