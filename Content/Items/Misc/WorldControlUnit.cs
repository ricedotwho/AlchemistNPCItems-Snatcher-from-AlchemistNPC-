using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCItems;
using AlchemistNPCItems.Content.Projectiles;

namespace AlchemistNPCItems.Content.Items.Misc
{
	public class WorldControlUnit : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Simalation Control Unit");
			/* Tooltip.SetDefault("Exclusive product, designed by Angela"
			+"\nLeft click to change between day and night time"
			+"\nRight click to enable or disable rain (sandstorm in desert)"); */
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.rare = 5;
			Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 4;
			Item.consumable = false;
            Item.value = 333333;
			Item.shopCustomPrice = 1000000;
        }
		
		public override bool CanRightClick()
        {            
            return true;
        }

		public override bool ConsumeItem(Player player)
		{
			return false;
		}

        public override void RightClick(Player player)
        {
			Projectile.NewProjectile(player.GetSource_FromAI(), player.Center, Vector2.Zero, ModContent.ProjectileType<Sandrain>(), 0, 0, Main.myPlayer);
		}
		
		public override bool? UseItem(Player player)
        {
			if (Main.dayTime)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Time set to night"), 255, 255, 255);
				}
				Main.dayTime = false;
				Main.time = 0.0;
				return true;
			}
			if (!Main.dayTime)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Time set to day"), 255, 255, 255);
				}
				Main.dayTime = true;
				Main.time = 0.0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
