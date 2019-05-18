namespace Framework.Models
{
    public class MirrorCard : Card
    {
        public override string Name => "Mirror";

        public override int Cost => 1;

        public override string Description => "Mirrors your last card played for +1 Elixir. Does not appear in your starting hand.";

        public override string Category => "Spell";

        public override string Arena => "Arena 12";

        public override string Rarity => "Epic";
    }
}
