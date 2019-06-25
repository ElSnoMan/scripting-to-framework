using System.Collections.Generic;
using Framework.Models;
using Framework.Services;
using NUnit.Framework;
using Royale.Pages;
using Tests.Base;

namespace Tests
{
    [Parallelizable]
    public class CardTests : TestBase
    {
        static IList<Card> apiCards = new ApiCardService().GetAllCards();

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
