using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dnd_Character_Sheet.Models
{
    public class Race
    {
        public string Name{ get; set; }
        public int[] AbiBonus { get; set; }
        public size Size;
        public int BaseSpeed{ get; set; }
        public bool[] Languages;
        public List<string> Subraces;
        public Race(string name, int str, int dex, int con, int intel, int wis, int cha, int baseSpeed, size size, bool common, bool dwarf, bool elf, bool giant, bool gnome, bool goblin, bool halfling, bool orc, bool abyssal, bool celestial, bool draconic, bool deepSpeech, bool infernal, bool primordial, bool sylvan, bool undercommon)
        {
            Languages = new bool[16];
            AbiBonus = new int[6];
            Subraces = new List<string>();
            Name = name;
            Size = size;
            BaseSpeed = baseSpeed;
            AbiBonus[0] = str;
            AbiBonus[1] = dex;
            AbiBonus[2] = con;
            AbiBonus[3] = intel;
            AbiBonus[4] = wis;
            AbiBonus[5] = cha;

            Languages[0] = common;
            Languages[1] = dwarf;
            Languages[2] = elf;
            Languages[3] = giant;
            Languages[4] = gnome;
            Languages[5] = goblin;
            Languages[6] = halfling;
            Languages[7] = orc;
            Languages[8] = abyssal;
            Languages[9] = celestial;
            Languages[10] = draconic;
            Languages[11] = deepSpeech;
            Languages[12] = infernal;
            Languages[13] = primordial;
            Languages[14] = sylvan;
            Languages[15] = undercommon;

        }
        public Race()
        {
            Languages = new bool[16];
            AbiBonus = new int[6];
            Subraces = new List<string>();
        }
        public void AddSubrace(Subrace subrace)
        {
            Subraces.Add(subrace.ToString());
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class Subrace
    {
        public string Name { get; set; }
        public int[] AbiBonus { get; set; }
        public Subrace(string name, int str, int dex, int con, int intel, int wis, int cha)
        {
            AbiBonus = new int[6];
            Name = name;
            AbiBonus[0] = str;
            AbiBonus[1] = dex;
            AbiBonus[2] = con;
            AbiBonus[3] = intel;
            AbiBonus[4] = wis;
            AbiBonus[5] = cha;
        }
        public Subrace()
        {
            AbiBonus = new int[6];
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
