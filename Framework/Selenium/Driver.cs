using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            _driver = new ChromeDriver();
            Wait = new Wait(waitSeconds);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null. Call Driver.Init() first.");

        public static void Goto(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            Debug.WriteLine($"Navigate to {url}");
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
    }
}
