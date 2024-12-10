﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using Microsoft.Xna.Framework;
using AlchemistNPCItems.Content.Buff;
using AlchemistNPCItems.Content.Projectiles;
using Terraria.Audio;
using AlchemistNPCItems.Common.Configs;

namespace AlchemistNPCItems.Content.Projectiles
{
	public class Slinky : ModProjectile
	{
        public static int counter = 0;
		public override void SetDefaults()
		{
			Main.projFrames[Projectile.type] = 11;
			Projectile.width = 60;
			Projectile.height = 6;
			Main.projPet[Projectile.type] = true;
			Projectile.hostile = false;
			Projectile.friendly = false;
			Projectile.tileCollide = false;
			Projectile.CloneDefaults(ProjectileID.BlackCat);
			AIType = ProjectileID.BlackCat;
		}

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Slinky");
		}

		public override bool PreAI()
        {
			Player player = Main.player[Projectile.owner];
			player.blackCat = false;
			return true;
        }

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
			if (player.dead || !player.HasBuff(ModContent.BuffType<Content.Buff.Slinky>()))
			{
				modPlayer.slinky = false;
			}
			if (modPlayer.slinky)
			{
				Projectile.timeLeft = 2;
			}

            var conf = ModContent.GetInstance<ItemConfig>();

			if (conf.enableSSB == true)
			{
                if (modPlayer.SnatcherCounter >= 15000)
                {
                    if (counter < 100)
                    {
                        counter++;
                    }
                    for (int i = 0; i < 200; i++)
                    {
                        NPC target = Main.npc[i];

                        float shootToX = target.position.X + target.width * 0.5f - Projectile.Center.X;
                        float shootToY = target.position.Y + target.height * 0.5f - Projectile.Center.Y;
                        float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                        if (distance < 750f && target.catchItem == 0 && !target.dontTakeDamage && !target.friendly && target.active && player.HeldItem.damage > 0)
                        {
                            if (counter > 60)
                            {
                                int dmg = 1;
                                if (player.HeldItem.damage < 50)
                                {
                                    dmg = player.HeldItem.damage * 4;
                                }
                                else if (player.HeldItem.damage < 100)
                                {
                                    dmg = player.HeldItem.damage * 2;
                                }
                                else
                                {
                                    dmg = player.HeldItem.damage / 2;
                                }
                                Vector2 vel = new Vector2(0, -1);
                                vel *= 10f;
                                SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
                                for (int j = 0; j < 2; j++)
                                {
                                    Vector2 perturbedSpeed = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
                                    Vector2 perturbedSpeed1 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
                                    Vector2 perturbedSpeed2 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
                                    Vector2 perturbedSpeed3 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
                                    Vector2 perturbedSpeed4 = new Vector2(vel.X, vel.Y).RotatedByRandom(MathHelper.ToRadians(10));
                                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), target.Center.X, target.Center.Y + 48, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 0f);
                                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), target.Center.X, target.Center.Y + 48, perturbedSpeed1.X, perturbedSpeed1.Y, ModContent.ProjectileType<ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 0f);
                                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), target.Center.X, target.Center.Y + 48, perturbedSpeed2.X, perturbedSpeed2.Y, ModContent.ProjectileType<ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 3f);
                                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), target.Center.X, target.Center.Y + 48, perturbedSpeed3.X, perturbedSpeed3.Y, ModContent.ProjectileType<ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 3f);
                                    Projectile.NewProjectile(Projectile.GetSource_FromAI(), target.Center.X, target.Center.Y + 48, perturbedSpeed4.X, perturbedSpeed4.Y, ModContent.ProjectileType<ShadowBurst>(), dmg, 0, Main.myPlayer, 0f, 0f);
                                }
                                counter = 0;
                            }
                        }
                    }
                }
            }
		}
	}
}