﻿using LUWeapons.Content.Items.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using LUWeapons.Common.Player;
using System;

namespace LUWeapons.Content.Items.Weapons
{
    public class LUHandgun : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("LU Handgun");
            Tooltip.SetDefault("A weak handgun that grows stronger as it's used.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 42; // Hitbox width of the item.
            Item.height = 30; // Hitbox height of the item.
            Item.scale = 0.7f;
            Item.rare = ItemRarityID.Blue; // The color that the item's name will be in-game.

            // Use Properties
            Item.useTime = 28; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 28; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = false; // Whether or not you can hold click to automatically use it again.

            // The sound that this item plays when used.
            Item.UseSound = SoundID.Item11;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 5; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 1f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.crit = -3;

            // Gun Properties
            Item.shoot = ModContent.ProjectileType<HandgunBullet>(); // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 6f; // The speed of the projectile (measured in pixels per frame.)
            //Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -2f);
        }

        // How can I make the shots appear out of the muzzle exactly?
        // Also, when I do this, how do I prevent shooting through tiles?
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {

            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }

        public override void UpdateInventory(Player player)
        {
            int level = player.GetModPlayer<HandgunExperience>().LVL;
            float bonus = (float)Math.Log(level, 10);

            Item.useTime = 28 - (int)(7f * bonus); // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 28 - (int)(7f * bonus); // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.damage = 5 + (int)(15f * bonus); // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 1f + (1f * bonus); // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.crit = -3 + (int)(10f * bonus);
            Item.shootSpeed = 6f + (3f * bonus); // The speed of the projectile (measured in pixels per frame.)
        }

    }
}
