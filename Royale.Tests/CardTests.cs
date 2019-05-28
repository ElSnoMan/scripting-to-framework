using System;
using Framework.Models;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;



namespace Tests
{
    [TestFixture, Parallelizable]
    public class CardTests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://statsroyale.com";
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        static string[] cardNames = { "Ice Spirit", "Mirror" };

        [Test, Parallelizable(ParallelScope.Children)]
        [TestCaseSource("cardNames")]
        public void Card_is_on_cards_page(string name)
        {
            var cardsPage = new CardsPage(driver).Goto();
            Assert.That(cardsPage.GetCardByName(name).Displayed);
        }

        [Test, Parallelizable(ParallelScope.Children)]
        [TestCaseSource("cardNames")]
        public void Base_Metrics_are_correct_on_Card_Details_page(string name)
        {
            var cardsPage = new CardsPage(driver).Goto();
            cardsPage.GetCardByName(name).Click();

            var cardOnPage = new CardDetailsPage(driver).GetBaseCard();
            var card = new CardService().GetCard(name);

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Category, cardOnPage.Category);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
        }
    }
}
