using Framework.Models;

namespace Framework.Services
{
    public class InMemoryCardService : ICardService
    {
        public Card GetCard(string name)
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
