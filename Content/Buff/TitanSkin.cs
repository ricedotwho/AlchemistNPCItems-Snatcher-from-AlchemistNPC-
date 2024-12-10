using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System;
using System.Linq;

namespace AlchemistNPCItems.Content.Buff
{
	public class TitanSkin : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.debuff[Type] = false;
            bool canBeCleared = true;
        }
		public override void Update(Player player, ref int buffIndex)
		{
			if (NPC.downedMechBoss2)
			{
			player.buffImmune[39] = true;
			player.buffImmune[69] = true;
			}
			player.buffImmune[24] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			
		}
	}
}
