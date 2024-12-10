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
using AlchemistNPCItems.Content.Items.Equip;
using AlchemistNPCItems.Content.Items.Pet;
using AlchemistNPCItems.Common.Configs;

namespace AlchemistNPCItems.Content.Items.Weapons
{
	public class CounterMatter : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Counter Matter");
			/* Tooltip.SetDefault("Globe 199"
			+"\n[c/00FF00:Legendary Item]"
			+"\nDestroys nearby enemy projectiles"
			+"\nAfter blocking the projectile, your next strike will be 100% critical"
			+"\n[c/00FF00:Stats are growing through progression]"); */
        }
		
		public override void SetDefaults()
		{
			Item.mana = 100;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.value = Terraria.Item.buyPrice(gold: 20);
			Item.rare = 11;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.buffType = Mod.Find<ModBuff>("ProjCounter").Type;
			Item.scale = 0.5f;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 2, true);
			}
		}
	}
}
