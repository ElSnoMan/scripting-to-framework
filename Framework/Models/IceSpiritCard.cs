namespace Framework.Models
{
    public class IceSpritCard : Card
    {
        public override string Name { get; set; } = "Ice Spirit";

        public override int Cost { get; set; } = 1;

        public override string Description { get; set; } = "Spawns one lively little Ice Spirit to freeze a group of enemies. Stay frosty.";

        public override string Rarity { get; set; } = "Common";

        public override string Category { get; set; } = "Troop";

        public override string Arena { get; set; } = "Arena 8";
    }
}
