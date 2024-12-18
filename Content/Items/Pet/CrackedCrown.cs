﻿using System.Collections.Generic;
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
using AlchemistNPCItems.Content.Items.Equip;
using AlchemistNPCItems.Content.Items.Pet;
using AlchemistNPCItems.Common.Configs;

namespace AlchemistNPCItems.Content.Items.Pet
{
	public class CrackedCrown : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Cracked Crown");
			// Tooltip.SetDefault("Summons the soul hunting entity");
		}
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Carrot);
			Item.width = 34;
			Item.height = 34;
			Item.value = Terraria.Item.buyPrice(platinum: 120);
			Item.shoot = Mod.Find<ModProjectile>("Snatcher").Type;
			Item.buffType = Mod.Find<ModBuff>("Snatcher").Type;
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
                .AddRecipeGroup("IronBar", 5)
                .AddIngredient(ModContent.ItemType<VerySoftBlanket>(), 1)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
            }
        }
	}
}
