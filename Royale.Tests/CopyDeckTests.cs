using System;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using Royale.Pages;

namespace Tests
{
    public class CopyDeckTests
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

        [Test]
        [Category("copydeck")]
        public void User_can_copy_the_deck()
        {
            Pages.DeckBuilder.Goto().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.Yes();
            Assert.AreEqual(Pages.CopyDeck.Map.CopiedMessage.Text, "If clicking \"Yes\" has no response, please try to open this page in a web browser.");
        }
    }
}
