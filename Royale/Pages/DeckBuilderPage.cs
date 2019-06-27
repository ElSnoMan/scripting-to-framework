using Framework;
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
            HeaderNav.Map.DeckBuilderLink.Click();
            return this;
        }

        public void AddCardsManually()
        {
            Map.AddCardsManuallyLink.Click();
            Driver.Wait.Until(WaitConditions.ElementDisplayed(Map.CopyDeckIcon));
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
        public Element LoadCollectionTagField => Driver.FindElement(By.CssSelector(".deckBuilderInput__input > [placeholder='Tag #XXXXXX']"), "Load Collection Field");

        public Element LoadCollectionButton => Driver.FindElement(By.XPath("//button/span[contains(text(), 'Load Collection')]"), "Load Collection Button");

        public Element AddCardsManuallyLink => Driver.FindElement(By.XPath("//*[text()='add cards manually']"), "Add Cards Manually Link");

        public Element CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"), "Copy Deck Icon");
    }
}
