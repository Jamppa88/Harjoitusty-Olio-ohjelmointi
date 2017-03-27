using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Character_Sheet.Models
{
    class Race
    {
        public string Name{ get; set; }
        public int[] AbiBonus { get; set; }
        public size Size;
        public int BaseSpeed{ get; set; }
        public List<Trait> Traits;
        public List<Subrace> Subraces;
        public Race(string name, int str, int dex, int con, int intel, int wis, int cha, int baseSpeed, size size )
        {
            Traits = new List<Trait>();
            AbiBonus = new int[6];
            Subraces = new List<Subrace>();
            Name = name;
            Size = size;
            BaseSpeed = baseSpeed;
            AbiBonus[0] = str;
            AbiBonus[1] = dex;
            AbiBonus[2] = con;
            AbiBonus[3] = intel;
            AbiBonus[4] = wis;
            AbiBonus[5] = cha;

        }
        public void AddSubrace(Subrace subrace)
        {
            Subraces.Add(subrace);
        }
        public override string ToString()
        {
            return Name;
        }
    }
    class Subrace
    {
        public string Name { get; set; }
        public int[] AbiBonus { get; set; }
        public List<Trait> Traits;
        public Subrace(string name, int str, int dex, int con, int intel, int wis, int cha)
        {
            Traits = new List<Trait>();
            AbiBonus = new int[6];
            Name = name;
            AbiBonus[0] = str;
            AbiBonus[1] = dex;
            AbiBonus[2] = con;
            AbiBonus[3] = intel;
            AbiBonus[4] = wis;
            AbiBonus[5] = cha;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
