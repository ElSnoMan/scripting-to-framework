using System.Collections.Generic;
using Framework.Models;

namespace Framework.Services
{
    public interface ICardService
    {
        Card GetCardByName(string name);

        IList<Card> GetAllCards();
    }
}
