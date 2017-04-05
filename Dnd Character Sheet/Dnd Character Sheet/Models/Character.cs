using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Dnd_Character_Sheet.Models
{
    public class Character
    {
        // Get other classes into Character
        public string Race { get; set; }
        public string Subrace { get; set; }
        public string Class { get; set; }
        public alignment Alignment { get; set; }
        public string Archetype { get; set; }
        public string Background { get; set; }
        // Define own variables
        public string Name{ get; set; }
        public int Speed { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        private int profiency;              // Needs a method!
        public int Profiency { get { return profiency; } }
        // Ability scores and related
        public int[] AbiScore { get; set; }
        private int[] abiMod;               // Needs a method!
        public int[] Abimod
        {
            get
            {
                return abiMod;
            }
        }
        public bool[] Saves;
        // Skills and profiencies to them
        private int[] skills;               // Needs a method!

        public int[] Skills
        {
            get { return skills; }
        }
        public bool[] SkillProf { get; set; }
        public bool[] SkillExp { get; set; }
        public bool[] SkillHalfProf { get; set; }
        public bool[] Languages;

        // Health related
        private int healthMax;              // Needs a method!
        public int HealthMax { get { return healthMax; } }
        public int[] HpRolls;
        private int healthCurr;             // Maybe a method?
        public int HealthCurr
        {
            get { return healthCurr; } 
            set {
                if (value < 0)
                    healthCurr = 0;
                else if (value > healthMax)
                    healthCurr = healthMax;
                else
                    healthCurr = value;
            }
        }
        public int HealthTemp { get; set; }
        // Features and traits
        public List<string> Features;
        public List<string> Traits;

        public Character()
        {
            AbiScore = new int[6];
            abiMod = new int[6];
            HpRolls = new int[20];
            Saves = new bool[6];
            SkillProf = new bool[18];
            SkillHalfProf = new bool[18];
            SkillExp = new bool[18];
            skills = new int[18];
            Languages = new bool[16];
            Traits = new List<string>();
            Features = new List<string>();
        }

        public void UpdateAbiMod()
        {
            for (int i = 0; i < 6; i++)
            {
                if (AbiScore[i] >= 10)
                    abiMod[i] = ((AbiScore[i] - 10) / 2);
                else
                    abiMod[i] = ((AbiScore[i] - 11) / 2);
            }
        }
        public void SetHPMax()
        {
            healthMax = 0;
            foreach (int i in HpRolls)
            {
                if (i != 0) { healthMax += i + Abimod[2]; }
            }
        }
    }
}
