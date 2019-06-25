using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _driver = DriverFactory.Build(FW.Config.Driver.Browser);
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

        public static Element FindElement(By by, string elementName)
        {
            return new Element(Current.FindElement(by), elementName);
        }

        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }

        public static void Quit()
        {
            FW.Log.Info("Close browser");
            Current.Quit();
            Current.Dispose();
        }
    }
}
