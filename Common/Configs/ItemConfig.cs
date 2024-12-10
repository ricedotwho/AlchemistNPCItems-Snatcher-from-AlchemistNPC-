using System;
using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.Utilities;
using AlchemistNPCItems.Content.Items.Pet;
using AlchemistNPCItems.Content.Items.Equip;
using AlchemistNPCItems;
using Terraria.IO;
using Terraria.ModLoader.Config;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AlchemistNPCItems.Common.Configs
{
    public class ItemConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("DropChances")]

        // Cracked Crown Drop Chance
        [Range(1, 100000)]
        [DefaultValue(33333)]
        [Increment(100)]
        public int SnatcherDropChance;

        // Leg Item Drop Chance
        [Range(1, 100000)]
        [DefaultValue(25000)]
        [Increment(100)]
        public int LegItemDrop;

        [Header("Enable/Disable")]

        // Cracked Crown
        [DefaultValue(true)] public bool enableSnatcher;

        // Very Soft Blanket
        [DefaultValue(false)]
        [ReloadRequired]
        public bool enableSlinky;

        // Blanket better than Cracked Crown y/n
        [DefaultValue(false)]
        public bool buffSlinky;

        // Nerf CC
        [DefaultValue(false)] public bool nerfCC;

        // Bungus Toggle
        [DefaultValue(false)] public bool enableBFungus;

        // Counter Matter Toggle
        [DefaultValue(true)] public bool enableCMatter;

        // World Warper Toggle
        [DefaultValue(true)] public bool enableWW;

        // Simulation Unit Toggle
        [DefaultValue(true)] public bool enableSCU;

        // Shadow Burst Toggle
        [DefaultValue(true)] public bool enableSSB;

        // Dont Let People Change Config On a Server
        [DefaultValue(false)]
        public bool cannotChangeConfigOnServer;


        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            if (Main.netMode == NetmodeID.Server && cannotChangeConfigOnServer == true)
            {
                message = "Clients cannot change config on Server! (You can disable this in the Config!)";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}