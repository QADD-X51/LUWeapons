﻿using LUWeapons.Content.Items.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using LUWeapons.Common.Player;

namespace LUWeapons.Content.Items.Weapons
{
    public class LUHandgunV4 : ModItem
    {
        //public int gunEXP = 0;
        //public int gunEXPRequirement = 500;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("LU Handgun V4");
            Tooltip.SetDefault("V4 - Imporoved firepower");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 42; // Hitbox width of the item.
            Item.height = 30; // Hitbox height of the item.
            Item.scale = 0.7f;
            Item.rare = ItemRarityID.LightRed; // The color that the item's name will be in-game.

            // Use Properties
            Item.useTime = 14; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 14; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = false; // Whether or not you can hold click to automatically use it again.

            // The sound that this item plays when used.
            Item.UseSound = SoundID.Item11;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type to ranged.
            Item.damage = 40; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 2.5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.crit = 3;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder; //ModContent.ProjectileType<NormalBullet>(); // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 8f; // The speed of the projectile (measured in pixels per frame.)
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the ammo type.
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

        public override void AddRecipes()
        {
            Recipe recipeCorr = CreateRecipe();
            recipeCorr.AddIngredient(ItemID.Bone, 1);
            recipeCorr.AddIngredient(ModContent.ItemType<LUHandgunV3>(), 1);
            recipeCorr.Register();

            Recipe recipeCrim = CreateRecipe();
            recipeCrim.AddIngredient(ItemID.Bone, 1);
            recipeCrim.AddIngredient(ModContent.ItemType<LUHandgunV3>(), 1);
            recipeCrim.Register();
        }

    }
}
