using Terraria;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace LUWeapons.Common.Player
{
    public enum WeaponExperienceType
    {
        HandgunV1
    }

    // See Common/Systems/KeybindSystem for keybind registration.
    public class WeaponExperience : ModPlayer
    {
        public const int baseEXP = 50;
        public const float levelUpMultiplier = 1.75f;

        public int handgunV1EXP = 0;
        public int handgunV1MaxEXP = baseEXP;
        public int handgunV1LVL = 1;

        public float baseExpMultiplier = 0.1f;
        public float buffExpMultiplier = 0f;

        public void GiveEXP(int ammount, WeaponExperienceType weapon)
        {
            int modifiedAmmount = (int)((float)ammount * (baseExpMultiplier + buffExpMultiplier));
            switch (weapon)
            {
                case WeaponExperienceType.HandgunV1:

                    if (modifiedAmmount == 0)
                        ++handgunV1EXP;

                    handgunV1EXP +=  modifiedAmmount;

                    if (handgunV1EXP >= handgunV1MaxEXP)
                    {
                        LevelUp(weapon);
                    }
                    return;

                default:
                    return;
            }
            
 
        }

        public void LevelUp(WeaponExperienceType weapon)
        {
            switch(weapon)
            {
                case WeaponExperienceType.HandgunV1:
                    handgunV1EXP = 0;
                    ++handgunV1LVL;
                    handgunV1MaxEXP = (int)(handgunV1MaxEXP * levelUpMultiplier);
                    break;

                default:
                    return;
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Set("Handgun V1 EXP", handgunV1EXP);
            tag.Set("Handgun V1 LVL", handgunV1LVL);
            tag.Set("Handgun V1 Max EXP", handgunV1MaxEXP);
        }

        public override void LoadData(TagCompound tag)
        {
            handgunV1EXP = tag.GetInt("Handgun V1 EXP");
            handgunV1LVL = tag.GetInt("Handgun V1 LVL");
            handgunV1MaxEXP = tag.GetInt("Handgun V1 Max EXP");
        }
    }
}
