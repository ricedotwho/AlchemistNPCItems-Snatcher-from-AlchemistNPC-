﻿using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPCItems.Content.Items.Equip
{
    public class bustlingfungus : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bustling Fungus");
            // Tooltip.SetDefault("Provides life regeneration while standing still");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 23;
            Item.value = Terraria.Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.scale = 0.01f;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 5;
        }
    }
}
