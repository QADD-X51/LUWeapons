using Terraria;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace LUWeapons.Common.Player
{

    // See Common/Systems/KeybindSystem for keybind registration.
    public class WeaponExperience : ModPlayer
    {

        public const float baseExpMultiplier = 0.1f;

        public float levelUpMultiplier;

        public int EXP;
        public int MaxEXP;
        public int LVL;

        public static float buffExpMultiplier;


        public WeaponExperience()
        {
            buffExpMultiplier = 0f;
        }


        public void GiveEXP(int ammount)
        {
            int modifiedAmmount = (int)((float)ammount * (baseExpMultiplier + buffExpMultiplier));

            if (modifiedAmmount == 0)
                ++EXP;
            
            EXP +=  modifiedAmmount;
            
            if (EXP >= MaxEXP)
            {
                LevelUp();
            }
            
 
        }

        public void LevelUp()
        {
            EXP = 0;
            ++LVL;
            MaxEXP = (int)(MaxEXP * levelUpMultiplier);
        }

    }
}
