using System;
using Framework.Models;
using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Royale.Pages;

namespace Tests
{
    [Parallelizable]
    public class CardTests
    {
        [SetUp]
        public void Setup()
        {
            Driver.Init();
            Pages.Init();
            Driver.Goto("statsroyale.com");
        }

        [TearDown]
        public void Teardown()
        {
            Driver.Current.Quit();
        }

        static string[] cardNames = { "Ice Spirit", "Mirror" };

        [Test, Parallelizable(ParallelScope.Children)]
        [TestCaseSource("cardNames")]
        [Category("cards")]
        public void Card_is_on_cards_page(string name)
        {
            var card = Pages.Cards.Goto().GetCardByName(name);
            Assert.That(card.Displayed);
        }

        [Test, Parallelizable(ParallelScope.Children)]
        [TestCaseSource("cardNames")]
        [Category("cards")]
        public void Base_Metrics_are_correct_on_Card_Details_page(string name)
        {
            Pages.Cards.Goto().GetCardByName(name).Click();
            var cardOnPage = Pages.CardDetails.GetBaseCard();
            var card = new InMemoryCardService().GetCardByName(name);

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Category, cardOnPage.Category);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
        }
    }
}
