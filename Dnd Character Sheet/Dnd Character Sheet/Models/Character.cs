using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Character_Sheet.Models
{
    class Character
    {
        // Get other classes into Character
        public Race Race { get; set; }
        public Class Class { get; set; }
        public Background Background { get; set; }
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
        // Skills and profiencies to them
        private int[] skills;               // Needs a method!

        public int[] Skills
        {
            get { return skills; }
        }
        public bool[] SkillProf { get; set; }
        public bool[] SkillExp { get; set; }
        public bool[] SkillHalfProf { get; set; }

        // Health related
        private int healthMax;              // Needs a method!
        public int HealthMax { get { return healthMax; } }
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
    }
}
