using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.IO;

namespace LUWeapons.Common.Player
{
    public class HandgunExperience : WeaponExperience
    {
        public HandgunExperience()
        {
            levelUpMultiplier = 1.75f;
            EXP = 0;
            MaxEXP = 50;
            LVL = 1;
        }

        public override void SaveData(TagCompound tag)
        {
            tag.Set("Handgun EXP", EXP);
            tag.Set("Handgun LVL", LVL);
            tag.Set("Handgun Max EXP", MaxEXP);
        }

        public override void LoadData(TagCompound tag)
        {
            EXP = tag.GetInt("Handgun EXP");
            LVL = tag.GetInt("Handgun LVL");
            MaxEXP = tag.GetInt("Handgun Max EXP");
        }
    }
}
