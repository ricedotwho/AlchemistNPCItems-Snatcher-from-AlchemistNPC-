using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using AlchemistNPCItems.Content.Buff;

namespace AlchemistNPCItems.Content.Buff
{
	public class TankComb : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Tank Combination (w/Modded)");
			// Description.SetDefault("Combination of Swiftness, Endurance, Lifeforce, Ironskin, Obsidian Skin, Thorns, Regeneration, Titan Skin, Invincibility buffs");
			Main.debuff[Type] = false;
            bool canBeCleared = true;
        }
		
		public override void Update(Player player, ref int buffIndex)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			modPlayer.Defense8 = true;
			modPlayer.DR10 = true;
			modPlayer.Regeneration = true;
			modPlayer.Lifeforce = true;
			modPlayer.MS = true;
			player.longInvince = true;
			if (NPC.downedMechBoss2)
			{
				player.buffImmune[39] = true;
				player.buffImmune[69] = true;
			}
			player.buffImmune[24] = true;
			player.buffImmune[44] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
			player.lavaImmune = true;
			player.fireWalk = true;
			player.buffImmune[1] = true;
			player.buffImmune[2] = true;
			player.buffImmune[3] = true;
			player.buffImmune[5] = true;
			player.buffImmune[14] = true;
			player.buffImmune[113] = true;
			player.buffImmune[114] = true;
			player.buffImmune[ModContent.BuffType<LongInvincible>()] = true;
			player.buffImmune[ModContent.BuffType<TitanSkin>()] = true;
			if (player.thorns < 1.0)
			{
				player.thorns = 0.3333333f;
			}
			BuffLoader.Update(BuffID.ObsidianSkin, player, ref buffIndex);
		}
	}
}
