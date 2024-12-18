using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCItems;

namespace AlchemistNPCItems.Content.Items.Misc
{
	public class GlobalTeleporter : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("World Warper");
			/* Tooltip.SetDefault(@"Teleports you to any point of the map
Use right-click on full screen map to teleport
Will not work if any boss is alive
Breaks after use
''O, the azure justice, the crimson love,
In the name of the one buried in destiny,
I shall make an oath to the light,
that we will show those who
stand in front of us - the power of love!''"); */
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 99;
			Item.value = 333;
			Item.rare = 6;
			Item.shopCustomPrice= 333333;
		}
		
		public override void UpdateInventory(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).GlobalTeleporter = true;
		}
	}
}
