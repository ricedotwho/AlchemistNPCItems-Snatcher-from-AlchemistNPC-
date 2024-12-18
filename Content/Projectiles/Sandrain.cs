using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Terraria.GameContent.Events;
using Terraria.Localization;

namespace AlchemistNPCItems.Content.Projectiles
{
	public class Sandrain : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Sandrain");
		}

		public override void SetDefaults()
		{
			Projectile.width = 1;
			Projectile.height = 1;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.damage = 0;
			Projectile.timeLeft = 1;
		}
		
		public override void Kill(int timeLeft)
        {
			Player player = Main.player[Projectile.owner];
			if (player.ZoneDesert)
			{
				if (Sandstorm.Happening)
				{
					if (Main.netMode == 0 || Main.netMode == 1)
					{
						Main.NewText(Language.GetTextValue("Sandstorm Stopped"), 255, 255, 255);
					}
					Sandstorm.Happening = false;
					Sandstorm.TimeLeft = 0;
					return;
				}
				if (!Sandstorm.Happening)
				{
					if (Main.netMode == 0 || Main.netMode == 1)
					{
						Main.NewText(Language.GetTextValue(" Sandstorm Started"), 255, 255, 255);
					}
					Sandstorm.Happening = true;
					Sandstorm.TimeLeft = 36000;
					return;
				}
			}
			if (Main.raining)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue(" Rain Stopped"), 255, 255, 255);
				}
				Main.rainTime = 0;
				Main.maxRaining = 0f;
				Main.raining = false;
				return;
			}
			if (!Main.raining)
			{
				if (Main.netMode == 0 || Main.netMode == 1)
				{
					Main.NewText(Language.GetTextValue("Rain Started"), 255, 255, 255);
				}
				Main.rainTime = 24000;
				Main.maxRaining = 1f;
				Main.raining = true;
				return;
			}
		}
	}
}
