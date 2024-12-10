using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.Utilities;
using AlchemistNPCItems.Content.Items.Pet;
using AlchemistNPCItems.Content.Items.Equip;
using AlchemistNPCItems.Content.Items.Weapons;
using AlchemistNPCItems.Content.Items.Misc;
using AlchemistNPCItems;
using AlchemistNPCItems.Common.Configs;
using Terraria.ModLoader.Config;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Steamworks;

namespace AlchemistNPCItems
{
	public class ModGlobalNPC : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
			var conf = ModContent.GetInstance<ItemConfig>();
			if (conf.enableBFungus == true && !npc.SpawnedFromStatue) //BFungus Drop
            {
				if (npc.type == NPCID.ZombieMushroom || npc.type == NPCID.ZombieMushroomHat || npc.type == NPCID.AnomuraFungus || npc.type == NPCID.FungoFish || npc.type == NPCID.AnomuraFungus || npc.type == NPCID.FungiBulb || npc.type == NPCID.SporeBat || npc.type == NPCID.GiantFungiBulb || npc.type == NPCID.SporeSkeleton)
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<bustlingfungus>(), 3000)); 
            }

			if (conf.enableSnatcher == true && !npc.SpawnedFromStatue) //Snatcher Drop
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrackedCrown>(), conf.SnatcherDropChance)); 

			if (conf.enableCMatter == true && !npc.SpawnedFromStatue) //Counter Matter & other legendary item Drop
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CounterMatter>(), conf.LegItemDrop));
        }

        //Override NPC Shops
        public override void ModifyShop(NPCShop shop)
        {
            var conf = ModContent.GetInstance<ItemConfig>();
            if(shop.NpcType== NPCID.Merchant)
            {
                if (conf.enableWW)
                {
                    shop.Add(new Item(ModContent.ItemType<GlobalTeleporter>()), Condition.Hardmode);
                    shop.Add(new Item(ModContent.ItemType<GlobalTeleporterUp>()), Condition.DownedMoonLord);
                }

                if (conf.enableSCU)
                {
                    shop.Add(new Item(ModContent.ItemType<WorldControlUnit>()), Condition.DownedMechBossAny);
                }
            }
        }
    }
}