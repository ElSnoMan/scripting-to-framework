namespace Framework.Models
{
    public class IceSpritCard : Card
    {
        public override string Name => "Ice Spirit";

        public override int Cost => 1;

        public override string Description => "Spawns one lively little Ice Spirit to freeze a group of enemies. Stay frosty.";

        public override string Rarity => "Common";

        public override string Category => "Troop";

        public override string Arena => "Arena 8";
    }
}
