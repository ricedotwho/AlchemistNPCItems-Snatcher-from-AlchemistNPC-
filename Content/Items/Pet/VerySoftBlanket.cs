using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCItems;
using AlchemistNPCItems.Content.Items;
using AlchemistNPCItems.Content.Projectiles;
using AlchemistNPCItems.Content.Items.Materials;
using AlchemistNPCItems.Common.Configs;
using Terraria.ModLoader.Config;

namespace AlchemistNPCItems.Content.Items.Pet
{
	public class VerySoftBlanket : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Very soft blanket");
		}
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.UnluckyYarn);
			Item.width = 64;
			Item.height = 16;
			Item.value = Terraria.Item.buyPrice(platinum: 120);
			Item.shoot = Mod.Find<ModProjectile>("Slinky").Type;
			Item.buffType = Mod.Find<ModBuff>("Slinky").Type;
			Item.expert = true;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}

		public override void AddRecipes()
        {
			var conf = ModContent.GetInstance<ItemConfig>();
			if (conf.enableSlinky == true)
            {
				CreateRecipe()
                .AddIngredient(ModContent.ItemType<qualitysilk>(), 16)
				.AddIngredient(ModContent.ItemType<CrackedCrown>(), 1)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
            }
        }
	}
}
