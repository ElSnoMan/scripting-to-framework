using OpenQA.Selenium;

namespace Royale.Pages
{
    public abstract class PageBase
    {
        public readonly  TopNav TopNav;

        public PageBase(IWebDriver driver)
        {
            TopNav = new TopNav(driver);
        }
    }
}
