using Framework.Selenium;
using NUnit.Framework;
using Royale.Pages;
using Tests.Base;

namespace Tests
{
    public class CopyDeckTests : TestBase
    {
        [Test]
        [Category("copydeck")]
        public void User_can_copy_a_deck()
        {
            Pages.DeckBuilder.Goto().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Assert.Fail();
            Pages.CopyDeck.Yes();
            Assert.AreEqual(Pages.CopyDeck.Map.CopiedMessage.Text, "If clicking \"Yes\" has no response, please try to open this page in a web browser.");
        }

        [Test]
        [Category("copydeck")]
        public void User_opens_app_store()
        {
            Pages.DeckBuilder.Goto().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.No().OpenAppStore();
            Assert.AreEqual("‎Clash Royale on the App Store", Driver.Title);
        }

        [Test]
        [Category("copydeck")]
        public void User_opens_google_play()
        {
            Pages.DeckBuilder.Goto().AddCardsManually();
            Pages.DeckBuilder.CopySuggestedDeck();
            Pages.CopyDeck.No().OpenGooglePlay();
            Assert.AreEqual("Clash Royale - Apps on Google Play", Driver.Title);
        }
    }
}
