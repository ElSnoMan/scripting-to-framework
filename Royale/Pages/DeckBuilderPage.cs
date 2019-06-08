using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class DeckBuilderPage : PageBase
    {
        public readonly DeckBuilderPageMap Map;

        public DeckBuilderPage()
        {
            Map = new DeckBuilderPageMap();
        }

        public DeckBuilderPage Goto()
        {
            HeaderNav.Map.DeckBuilderTab.Click();
            return this;
        }

        public void AddCardsManually()
        {
            Map.AddCardsManuallyLink.Click();
            Driver.Wait.Until(drvr => Map.CopyDeckIcon.Displayed);
        }

        public void LoadCollection(string profileTag)
        {
            Map.LoadCollectionTagField.SendKeys(profileTag);
            Map.LoadCollectionButton.Click();
        }

        public void CopySuggestedDeck()
        {
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        public IWebElement LoadCollectionTagField => Driver.FindElement(By.CssSelector(".deckBuilderInput__input > [placeholder='Tag #XXXXXX']"));

        public IWebElement LoadCollectionButton => Driver.FindElement(By.XPath("//button/span[contains(text(), 'Load Collection')]"));

        public IWebElement AddCardsManuallyLink => Driver.FindElement(By.XPath("//*[text()='add cards manually']"));

        public IWebElement CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"));
    }
}