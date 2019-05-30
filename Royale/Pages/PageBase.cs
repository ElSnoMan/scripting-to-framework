using OpenQA.Selenium;

namespace Royale.Pages
{
    public abstract class PageBase
    {
        public readonly  TopNav TopNav;

        public PageBase()
        {
            TopNav = new TopNav();
        }
    }
}
