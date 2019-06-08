using System;
using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }

        public void GotoCards()
        {
            Map.CardsTab.Click();
        }
    }

    public class HeaderNavMap
    {
        public IWebElement CardsTab => Driver.FindElement(By.CssSelector("a[href='/cards']"));

        public IWebElement DeckBuilderTab => Driver.FindElement(By.CssSelector("a[href='/deckbuilder']"));
    }
}
