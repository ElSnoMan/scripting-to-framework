namespace Framework.Models
{
    public class MirrorCard : Card
    {
        public override string Name { get; set; } = "Mirror";

        public override int Cost { get; set; } = 1;

        public override string Description { get; set; } = "Mirrors your last card played for +1 Elixir. Does not appear in your starting hand.";

        public override string Category { get; set; } = "Spell";

        public override string Arena { get; set; } = "Arena 12";

        public override string Rarity { get; set; } = "Epic";
    }
}
