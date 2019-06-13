using System;
using System.Collections.Generic;
using System.Linq;
using Framework;
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
        [OneTimeSetUp]
        public void BeforeAll()
        {
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Init();
            Driver.Goto("statsroyale.com");
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        static IList<Card> apiCards = new ApiCardService().GetAllCards();

        [Test]
        public void Mirror_is_on_cards_page()
        {
            var card = Pages.Cards.Goto().GetCardByName("Mirror");
            Assert.That(card.Displayed);
        }

        [Test, Parallelizable(ParallelScope.Children)]
        [TestCaseSource("apiCards")]
        [Category("cards")]
        public void Card_is_on_cards_page(Card apiCard)
        {
            var card = Pages.Cards.Goto().GetCardByName(apiCard.Name);
            Assert.That(card.Displayed);
        }

        [Test, Parallelizable(ParallelScope.Children)]
        [TestCaseSource("apiCards")]
        [Category("cards")]
        public void Base_Metrics_are_correct_on_Card_Details_page(Card card)
        {
            Pages.Cards.Goto().GetCardByName(card.Name).Click();
            var cardOnPage = Pages.CardDetails.GetBaseCard();

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
        }
    }
}
