using OpenQA.Selenium;

namespace Royale.Pages
{
    public class CardsPage : PageBase
    {
        public readonly CardsPageMap Map;

        public CardsPage(IWebDriver driver) : base(driver)
        {
            Map = new CardsPageMap(driver);
        }

        public CardsPage Goto()
        {
            TopNav.GotoCards();
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
        private readonly IWebDriver _driver;

        public CardsPageMap(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Card(string name) => _driver.FindElement(By.CssSelector($"a[href*='{name}']"));
    }
}
