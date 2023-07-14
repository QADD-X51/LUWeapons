using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LUWeapons.Common.Player
{
    public class ManaShieldPlayer : ModPlayer
    {
        public bool HasManaShieldAcc;

        // Always reset the accessory field to its default value here.
        public override void ResetEffects()
        {
            HasManaShieldAcc = false;
        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit, int cooldownCounter)
        {
            if (!HasManaShieldAcc || Player.manaSick || Player.manaRegenBuff) return;
            
            var manaDiff = Player.statMana - (int)damage * 3;

            if(manaDiff < 0)
            {
                Player.statLife += Player.statMana / 6;
                Player.statMana = 0;
                Player.manaRegenDelay = 0;
                Player.manaRegenCount = 0;
                Player.manaRegen = 0;
                return;
            }

            Player.statMana = manaDiff;
            Player.manaRegenDelay = 0;
            Player.manaRegenCount = 0;
            Player.manaRegen = 0;
            Player.statLife += (int)damage / 2;
        }
    }
}
