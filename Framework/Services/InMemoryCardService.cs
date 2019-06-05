using System.Collections.Generic;
using Framework.Models;

namespace Framework.Services
{
    public class InMemoryCardService : ICardService
    {
        public IList<Card> GetAllCards()
        {
            throw new System.NotImplementedException("InMemoryCardService only has access to two cards.");
        }

        public Card GetCardByName(string name)
        {
            switch (name)
            {
                case "Ice Spirit":
                    return new IceSpritCard();

                case "Mirror":
                    return new MirrorCard();

                default:
                    throw new System.ArgumentException($"Card not found: {name}");
            }
        }
    }
}
