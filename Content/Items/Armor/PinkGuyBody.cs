using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCItems.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class PinkGuyBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pink Guy's Suit [NYI]");
			// Tooltip.SetDefault("Forged from the darkest of materials. Only the best of the best can wear it.");
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 24;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}