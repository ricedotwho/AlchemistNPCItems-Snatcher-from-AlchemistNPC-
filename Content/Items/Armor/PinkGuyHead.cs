using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.LocalizationLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPCItems.Content.Items;
using AlchemistNPCItems.Content.Items.Armor;
using AlchemistNPCItems.Content.Items.Equip;
using AlchemistNPCItems.Content.Buff;

namespace AlchemistNPCItems.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PinkGuyHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Pink Guy's Hood [NYI]");
			// Tooltip.SetDefault("Could this be a legendary piece of clothing? No one knows, but once you wear it, you can't go back.");
			 
            //LocalizedText text = CreateTranslation("PGSetBonus");
		    /* text.SetDefault("Increases current ranged/melee damage by 15% and adds 15% to ranged/melee critical strike chance"
		    + "\n+56 defense"
		    + "\nIncreases movement speed greatly"
		    + "\nPlayer is under permanent effect of Tank Combination"
            + "\nNational Ugandan Treasure can now be dropped from Moon Lord"); */
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<PinkGuyBody>() && legs.type == ModContent.ItemType<PinkGuyLegs>();
		}

		public override void UpdateArmorSet(Player player)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            modPlayer.PGSWear = true;
            string PGSetBonus = Language.GetTextValue("Increases current ranged/melee damage by 15% and adds 15% to ranged/melee critical strike chance"
            + "\n+56 defense"
            + "\nIncreases movement speed greatly"
            + "\nPlayer is under permanent effect of Tank Combination"
            + "\nNational Ugandan Treasure can now be dropped from Moon Lord");
            player.setBonus = PGSetBonus;
            player.statDefense += 56;
            player.GetDamage(DamageClass.Generic) += 0.15f;
            player.GetCritChance(DamageClass.Generic) += 15;
			player.moveSpeed += 0.50f;
			player.AddBuff(ModContent.BuffType<TankComb>(), 2);
		}
	}
}