﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCItems;
using AlchemistNPCItems.Content.Items;
using AlchemistNPCItems.Content.Projectiles;
using AlchemistNPCItems.Content.Items.Materials;
using Terraria.GameContent.Creative;
using Terraria.ModLoader.Config;
using AlchemistNPCItems.Common.Configs;

namespace AlchemistNPCItems.Content.Items.Materials
{
    internal class qualitysilk : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Quality Silk");
            // Tooltip.SetDefault("It's very soft");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
        }

        public override void SetDefaults()
        {
            Item.width = 26; // Hitblox Width from bottom center
            Item.height = 28; // Hitbox height from bottom center

            Item.value = Terraria.Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Purple;
            Item.maxStack = 999;
        }

        public override void AddRecipes()
        {
            var conf = ModContent.GetInstance<ItemConfig>();
            if (conf.enableSlinky == true)
            {
                CreateRecipe()
                .AddIngredient(ItemID.Silk, 10)
                .AddIngredient(ItemID.FragmentVortex, 5)
                .AddIngredient(ItemID.FragmentSolar, 5)
                .AddIngredient(ItemID.FragmentNebula, 5)
                .AddIngredient(ItemID.FragmentStardust, 5)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
            }
        }
    }
}
