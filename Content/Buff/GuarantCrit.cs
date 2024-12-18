using System;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCItems.Content.Buff
{
    public class GuarantCrit : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Guaranteed Crit");
            // Description.SetDefault("Your next attack will be critical hit");
            Main.persistentBuff[Type] = true;
            bool canBeCleared = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Generic) += 100;
            player.AddBuff(Mod.Find<ModBuff>("GuarantCrit").Type, 2);
            if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).GC == false)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
