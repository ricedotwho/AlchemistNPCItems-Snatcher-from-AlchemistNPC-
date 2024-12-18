﻿using Terraria;
using static Terraria.Player;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using System.Linq;
using AlchemistNPCItems;
using AlchemistNPCItems.Common.Configs;

namespace AlchemistNPCItems.Content.Buff
{
    public class Slinky : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Slinky");
            // Description.SetDefault("Snatcher reskin");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            //Declare and set vars to default
            string buffMoveSpeedTT = ("25%");
            string buffDef = ("10");
            string buffDR = ("10%");
            string buffMinions = ("1");
            string buffDmg = ("8%");
            string buffCC = ("5%");
            string buffPen = ("20");
            string buffLife = ("10%");

            //Buff or not Buff
            var conf = ModContent.GetInstance<ItemConfig>();
            if (conf.buffSlinky == true)
            {
                buffMoveSpeedTT = ("30%");
                buffDef = ("15");
                buffDR = ("10%");
                buffMinions = ("2");
                buffDmg = ("10%");
                buffCC = ("10%");
                buffPen = ("20");
                buffLife = ("20%");
            }
            if(conf.nerfCC== true)
            {
                conf.buffSlinky = false;
                buffMoveSpeedTT = ("15%");
                buffDef = ("5");
                buffDR = ("5%");
                buffMinions = ("1");
                buffDmg = ("5%");
                buffCC = ("5%");
                buffPen = ("10");
                buffLife = ("5%");
            }

            Player player = Main.player[Main.myPlayer];
            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            tip = "Snatcher reskin"
            + "\n" + modPlayer.SnatcherCounter + " souls collected.";


            if (modPlayer.SnatcherCounter >= 500)
            {
                tip += "\nIncreases your movement speed by " + buffMoveSpeedTT;
            }
            if (modPlayer.SnatcherCounter >= 1000)
            {
                tip += "\nIncreases your defense by " + buffDef;
            }
            if (modPlayer.SnatcherCounter >= 1500)
            {
                tip += "\nIncreases your damage reduction by " + buffDR;
            }
            if (modPlayer.SnatcherCounter >= 2500)
            {
                tip += "\nIncreases max amount of minions/sentries by " + buffMinions;
            }
            if (modPlayer.SnatcherCounter >= 3500)
            {
                tip += "\nBoosts all damage types by " + buffDmg;
            }
            if (modPlayer.SnatcherCounter >= 5000)
            {
                tip += "\nBoosts all critical strike chances by " + buffCC;
            }
            if (modPlayer.SnatcherCounter >= 6666)
            {
                tip += "\nIncreases your armor penetration by " + buffPen;
            }
            if (modPlayer.SnatcherCounter >= 9999)
            {
                tip += "\nBoosts your max life by " + buffLife;
            }
            if (modPlayer.SnatcherCounter >= 12500)
            {
                tip += "\nReflects 1000% damage taken back to the attacker";
            }
            if (modPlayer.SnatcherCounter >= 15000)
            {
                tip += "\nSupports you by scratching nearby enemies.\nDamage is calculated depending from current weapon in hands";
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            //Declare and set vars to default
            float buffMoveSpeed = (0.25f);
            int buffDef = (10);
            float buffDR = (0.1f);
            int buffMinions = (1);
            float buffDmg = (0.08f);
            int buffCC = (5);
            int buffPen = (20);
            int buffLife = (10);

            //Buff or not Buff
            var conf = ModContent.GetInstance<ItemConfig>();
            if (conf.buffSlinky == true)
            {
                buffMoveSpeed = (0.3f);
                buffDef = (15);
                buffDR = (0.1f);
                buffMinions = (2);
                buffDmg = (0.1f);
                buffCC = (10);
                buffPen = (20);
                buffLife = (5);
            }

            if(conf.nerfCC== true)
            {
                conf.buffSlinky = false;
                buffMoveSpeed = (0.15f);
                buffDef = (5);
                buffDR = (0.05f);
                buffMinions = (1);
                buffDmg = (0.05f);
                buffCC = (5);
                buffPen = (10);
                buffLife = (20);
            }


            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Slinky").Type] > 0)
            {
                modPlayer.slinky = true;
            }
            if (!modPlayer.slinky)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
            bool petProjectileNotSpawned = true;
            if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Slinky").Type] > 0)
            {
                petProjectileNotSpawned = false;
            }
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_FromAI(), player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, Mod.Find<ModProjectile>("Slinky").Type, 0, 0f, player.whoAmI, 0f, 0f);
            }
            if (modPlayer.SnatcherCounter >= 500)
            {
                player.moveSpeed += buffMoveSpeed;
            }
            if (modPlayer.SnatcherCounter >= 1000)
            {
                player.statDefense += buffDef;
            }
            if (modPlayer.SnatcherCounter >= 1500)
            {
                player.endurance += buffDR;
            }
            if (modPlayer.SnatcherCounter >= 2500)
            {
                player.maxMinions += buffMinions;
                player.maxTurrets += buffMinions;
            }
            if (modPlayer.SnatcherCounter >= 3500)
            {
                player.GetDamage(DamageClass.Generic) += buffDmg;
            }
            if (modPlayer.SnatcherCounter >= 5000)
            {
                player.GetCritChance(DamageClass.Generic) += buffCC;
                /*player.GetCritChance(DamageClass.Melee) += 10;
                player.GetCritChance(DamageClass.Ranged) += 10;
                player.GetCritChance(DamageClass.Magic) += 10;
                player.GetCritChance(DamageClass.Throwing) += 10;
                player.GetCritChance(DamageClass.Summon) += 10;
                Mod Calamity = ModLoader.TryGetMod("CalamityMod", out Mod calamity);
                if (Calamity != null)
                {
                    Calamity.Call("AddRogueCrit", player, 5);
                }*/
            }
            if (modPlayer.SnatcherCounter >= 6666)
            {
                player.GetArmorPenetration(DamageClass.Generic) += buffPen;
            }
            if (modPlayer.SnatcherCounter >= 9999)
            {
                player.statLifeMax2 += player.statLifeMax / buffLife;
            }
        }
    }
}
