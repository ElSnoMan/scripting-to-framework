using System;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class TopNav
    {
        public readonly TopNavMap Map;

        public TopNav(IWebDriver driver)
        {
            Map = new TopNavMap(driver);
        }

        public void GotoCards()
        {
            Map.CardsTab.Click();
        }
    }

    public class TopNavMap
    {
        private readonly IWebDriver _driver;

        public TopNavMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CardsTab => _driver.FindElement(By.CssSelector("a[href='/cards']"));
    }
}
