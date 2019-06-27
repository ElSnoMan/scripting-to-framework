using System;
using OpenQA.Selenium;

namespace Framework.Selenium
{
    public sealed class WaitConditions
    {
        public static Func<IWebDriver, bool> ElementDisplayed(IWebElement element)
        {
            bool condition(IWebDriver driver)
            {
                return element.Displayed;
            }

            return condition;
        }

        public static Func<IWebDriver, bool> ElementNotDisplayed(IWebElement element)
        {
            bool condition(IWebDriver driver)
            {
                try
                {
                    return !element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
            }

            return condition;
        }

        public static Func<IWebDriver, Elements> ElementsNotEmpty(Elements elements)
        {
            Elements condition(IWebDriver driver)
            {
                Elements _elements = Driver.FindElements(elements.FoundBy);
                return _elements.IsEmpty ? null : _elements;
            }

            return condition;
        }
    }
}
