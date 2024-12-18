using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCItems.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class PinkGuyLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pink Guy's Leggings [NYI]");
			// Tooltip.SetDefault("The perfect pants for leg day. Perhaps they could even make you stronger.");
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 16;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}