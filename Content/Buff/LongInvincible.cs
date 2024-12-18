using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System;
using System.Linq;

namespace AlchemistNPCItems.Content.Buff
{
	public class LongInvincible : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = false;
            bool canBeCleared = true;
        }
		public override void Update(Player player, ref int buffIndex)
		{
			player.longInvince = true;
		}
	}
}
