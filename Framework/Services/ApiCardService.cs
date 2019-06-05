using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Framework.Services
{
    public class ApiCardService : ICardService
    {
        public const string CARD_API = "https://statsroyale.com/api/cards";

        public IList<Card> GetAllCards()
        {
            var client = new RestClient(CARD_API);
            var request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(
                    $"/cards endpoint failed with {response.StatusCode.ToString()} -> {response.Content}");
            }

            return JsonConvert.DeserializeObject<IList<Card>>(response.Content);
        }

        public Card GetCardByName(string name)
        {
            var cards = GetAllCards();
            return cards.FirstOrDefault(card => card.Name == name);
        }
    }
}
