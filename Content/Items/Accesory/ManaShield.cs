using LUWeapons.Common.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LUWeapons.Content.Items.Accesory
{
    public class ManaShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Use Mana to reduce damage taken by 50%\n" +
                                "Mana Regeneration Drastically Decreased\n" +
                                "Mana shield takes triple the non-reduced damage\n" +
                                "The accesory has no effect if either Mana Sickness or Mana Regeneration Buff is active");

            //CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ManaShieldPlayer>().HasManaShieldAcc = true;
            player.manaRegenBonus = -25;
        }
    }

    
}
