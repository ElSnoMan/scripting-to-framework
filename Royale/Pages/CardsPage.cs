using Framework.Selenium;
using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardsPage : PageBase
    {
        public readonly CardsPageMap Map;

        public CardsPage()
        {
            Map = new CardsPageMap();
        }

        public CardsPage Goto()
        {
            HeaderNav.GotoCards();
            return this;
        }

        public IWebElement GetCardByName(string cardName)
        {
            var formattedName = cardName;

            if (cardName.Contains(" "))
            {
                formattedName = cardName.Replace(" ", "+");
            }

            return Map.Card(formattedName);
        }
    }

    public class CardsPageMap
    {
        public Element Card(string name) => Driver.FindElement(By.CssSelector($"a[href*='{name}']"), $"Card: {name}");
    }
}
