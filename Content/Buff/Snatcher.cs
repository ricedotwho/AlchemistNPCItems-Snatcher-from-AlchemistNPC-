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
    public class Snatcher : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Snatcher, the Cursed Prince");
            /* Description.SetDefault("Uh... You don't seem to have a soul. What a shame. OK then, let's make a deal..."
            + "\nIn your journey, you are defeating an endless amounts of enemies..."
            + "\nBut you are not collecting their souls for yourself, right?"
            + "\nWhy not give them to me then? For certain amounts, I will give you some kind of rewards."
            + "\nDoes that sound good enough? I hope so..."); */
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            //Declare and set vars to defualt
            string buffMoveSpeedTT = ("25%");
            string buffDef = ("10");
            string buffDR = ("10%");
            string buffMinions = ("1");
            string buffDmg = ("8%");
            string buffCC = ("5%");
            string buffPen = ("20");
            string buffLife = ("10%");

            var conf = ModContent.GetInstance<ItemConfig>();
            if (conf.nerfCC == true)
            {
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
            tip = "Uh... You don't seem to have a soul. What a shame. OK then, let's make a deal..."
            + "\nIn your journey, you are defeating an endless amounts of enemies..."
            + "\nBut you are not collecting their souls for yourself, right?"
            + "\nWhy not give them to me then? For certain amounts, I will give you some kind of rewards."
            + "\nDoes that sound good enough? I hope so..."
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
                tip += "\nSupports you by attacking nearby enemies with shadow bursts\nDamage is calculated depending from current weapon in hands";
            }
        }

        public override void Update(Player player, ref int buffIndex)
        {
            var conf = ModContent.GetInstance<ItemConfig>();
            //Declare and set vars to default
            float buffMoveSpeed = (0.25f);
            int buffDef = (10);
            float buffDR = (0.1f);
            float buffDmg = (0.08f);
            int buffPen = (20);
            int buffLife = (10);

            if (conf.nerfCC == true)
            {
                buffMoveSpeed = (0.15f);
                buffDef = (5);
                buffDR = (0.05f);
                buffDmg = (0.05f);
                buffPen= (10);
                buffLife = (20);
            }

            AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Snatcher").Type] > 0)
            {
                modPlayer.snatcher = true;
            }
            if (!modPlayer.snatcher)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
            bool petProjectileNotSpawned = true;
            if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Snatcher").Type] > 0)
            {
                petProjectileNotSpawned = false;
            }
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_FromAI(), player.position.X + player.width / 2, player.position.Y + player.height / 2, 0f, 0f, Mod.Find<ModProjectile>("Snatcher").Type, 0, 0f, player.whoAmI, 0f, 0f);
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
                player.maxMinions += 1;
                player.maxTurrets += 1;
            }
            if (modPlayer.SnatcherCounter >= 3500)
            {
                player.GetDamage(DamageClass.Generic) += buffDmg;
            }
            if (modPlayer.SnatcherCounter >= 5000)
            {
                player.GetCritChance(DamageClass.Generic) += 5;
                /*player.GetCritChance(DamageClass.Melee) += 5;
                player.GetCritChance(DamageClass.Ranged) += 5;
                player.GetCritChance(DamageClass.Magic) += 5;
                player.GetCritChance(DamageClass.Throwing) += 5;
                player.GetCritChance(DamageClass.Summon) += 5;
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
