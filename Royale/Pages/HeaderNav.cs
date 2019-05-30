using System;
using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class TopNav
    {
        public readonly TopNavMap Map;

        public TopNav()
        {
            Map = new TopNavMap();
        }

        public void GotoCards()
        {
            Map.CardsTab.Click();
        }
    }

    public class TopNavMap
    {
        public IWebElement CardsTab => Driver.FindElement(By.CssSelector("a[href='/cards']"));
    }
}
