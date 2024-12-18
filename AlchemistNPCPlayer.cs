﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Utilities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Events;
using Terraria.GameContent.Tile_Entities;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.UI.Gamepad;
using Terraria.Utilities;
using Terraria.WorldBuilding;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using AlchemistNPCItems;
using AlchemistNPCItems.Content.Items;
using AlchemistNPCItems.Content.Items.Misc;
using AlchemistNPCItems.Content.Projectiles;

namespace AlchemistNPCItems
{
    public class AlchemistNPCPlayer : ModPlayer
    {
        public bool snatcher = false;
        public bool slinky = false;
        public bool bustlingfunguson = false;
        public bool GC = false;
        public bool GlobalTeleporter = false;
        public bool GlobalTeleporterUp = false;
        public bool AutoinjectorMK2 = false;
        public bool PGSWear = false;

        public bool AllDamage10 = false;
        public bool AllCrit10 = false;
        public bool Defense8 = false;
        public bool DR10 = false;
        public float EndurancePotDR = 0;
        public bool Regeneration = false;
        public bool Lifeforce = false;
        public bool MS = false;

        private const int maxSnatcherCounter = -1;
        public int SnatcherCounter = 0;


        protected override bool CloneNewInstances
        {
            get
            {
                return true;
            }
        }

        public override void ResetEffects()
        {
            snatcher = false;
            slinky = false;
            GlobalTeleporter = false;
            GlobalTeleporterUp = false;
            PGSWear = false;

            AllDamage10 = false;
            AllCrit10 = false;
            Defense8 = false;
            DR10 = false;
            Regeneration = false;
            Lifeforce = false;
            MS = false;
        }
        public override void CopyClientState(ModPlayer clientClone)/* tModPorter Suggestion: Replace Item.Clone usages with Item.CopyNetStateTo */
        {
            AlchemistNPCPlayer clone = clientClone as AlchemistNPCPlayer;
            clone.SnatcherCounter = SnatcherCounter;
        }

        public override void SendClientChanges(ModPlayer clientPlayer)
        {
            AlchemistNPCPlayer clone = clientPlayer as AlchemistNPCPlayer;
            if (clone.SnatcherCounter != SnatcherCounter)
            {
                var packet = Mod.GetPacket();
                packet.Write((byte)Player.whoAmI);
                packet.Write(SnatcherCounter);
                packet.Send();
            }
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("SnatcherCounter"))
		        SnatcherCounter = tag.GetInt("SnatcherCounter");
        }

        public override void SaveData(TagCompound tag)
        {
            tag["SnatcherCounter"] = SnatcherCounter;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Player.HasBuff(Mod.Find<ModBuff>("GuarantCrit").Type))
            {
                modifiers.FinalDamage.Base *= 2;
                GC = false;
            }
        }

        public override void OnHitByNPC(NPC npc, Player.HurtInfo hurtInfo)
        {
            if (SnatcherCounter >= 12500 && Player.HasBuff(Mod.Find<ModBuff>("Snatcher").Type) || SnatcherCounter >= 12500 && Player.HasBuff(Mod.Find<ModBuff>("Slinky").Type))
            {
                Projectile.NewProjectile(Player.GetSource_FromThis(), npc.Center.X, npc.Center.Y, 0f, 0f, Mod.Find<ModProjectile>("Returner2").Type, hurtInfo.Damage * 10, 0, Player.whoAmI);
            }
        }


        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.life <= 0 && Player.HasBuff(Mod.Find<ModBuff>("Snatcher").Type) || target.life <= 0 && !target.friendly && target.type != NPCID.EaterofWorldsBody && target.type != NPCID.TheDestroyerBody && !target.SpawnedFromStatue && target.type != NPCID.BlueSlime && target.type != NPCID.SlimeSpiked)
            {
                SnatcherCounter++;
            }
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (GlobalTeleporter || GlobalTeleporterUp)
            {
                bool allow = true;
                for (int v = 0; v < 200; ++v)
                {
                    NPC npc = Main.npc[v];
                    if (npc.active && npc.boss)
                    {
                        allow = false;
                        break;
                    }
                }
                if (GlobalTeleporterUp && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                {
                    int mapWidth = Main.maxTilesX * 16;
                    int mapHeight = Main.maxTilesY * 16;
                    Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

                    cursorPosition.X -= Main.screenWidth / 2;
                    cursorPosition.Y -= Main.screenHeight / 2;

                    Vector2 mapPosition = Main.mapFullscreenPos;
                    Vector2 cursorWorldPosition = mapPosition;

                    cursorPosition /= 16;
                    cursorPosition *= 16 / Main.mapFullscreenScale;
                    cursorWorldPosition += cursorPosition;
                    cursorWorldPosition *= 16;

                    cursorWorldPosition.Y -= Player.height;
                    if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
                    else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
                    if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
                    else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;

                    Player.Teleport(cursorWorldPosition, 0, 0);
                    NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)cursorWorldPosition.X, (float)cursorWorldPosition.Y, 1, 0, 0);
                    Main.mapFullscreen = false;

                    for (int index = 0; index < 120; ++index)
                        Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
                }
                if (GlobalTeleporter && allow && Main.mapFullscreen == true && Main.mouseRight && Main.keyState.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.LeftControl))
                {
                    int mapWidth = Main.maxTilesX * 16;
                    int mapHeight = Main.maxTilesY * 16;
                    Vector2 cursorPosition = new Vector2(Main.mouseX, Main.mouseY);

                    cursorPosition.X -= Main.screenWidth / 2;
                    cursorPosition.Y -= Main.screenHeight / 2;

                    Vector2 mapPosition = Main.mapFullscreenPos;
                    Vector2 cursorWorldPosition = mapPosition;

                    cursorPosition /= 16;
                    cursorPosition *= 16 / Main.mapFullscreenScale;
                    cursorWorldPosition += cursorPosition;
                    cursorWorldPosition *= 16;

                    cursorWorldPosition.Y -= Player.height;
                    if (cursorWorldPosition.X < 0) cursorWorldPosition.X = 0;
                    else if (cursorWorldPosition.X + Player.width > mapWidth) cursorWorldPosition.X = mapWidth - Player.width;
                    if (cursorWorldPosition.Y < 0) cursorWorldPosition.Y = 0;
                    else if (cursorWorldPosition.Y + Player.height > mapHeight) cursorWorldPosition.Y = mapHeight - Player.height;

                    Player.Teleport(cursorWorldPosition, 0, 0);
                    NetMessage.SendData(65, -1, -1, (NetworkText)null, 0, (float)Player.whoAmI, (float)cursorWorldPosition.X, (float)cursorWorldPosition.Y, 1, 0, 0);
                    Main.mapFullscreen = false;
                    Item[] inventory = Player.inventory;
                    for (int k = 0; k < inventory.Length; k++)
                    {
                        if (inventory[k].type == ModContent.ItemType<GlobalTeleporter>())
                        {
                            inventory[k].stack--;
                            break;
                        }
                    }
                    for (int index = 0; index < 120; ++index)
                        Main.dust[Dust.NewDust(Player.position, Player.width, Player.height, 15, Main.rand.NextFloat(-10f, 10f), Main.rand.NextFloat(-10f, 10f), 150, Color.Cyan, 1.2f)].velocity *= 0.75f;
                }
            }
        }
    }
}