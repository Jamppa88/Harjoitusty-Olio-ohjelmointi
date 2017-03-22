using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Character_Sheet.Models
{
    
    class Spell
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpellLvl { get; set; }
        public string MaterialComponent { get; set; }
        public bool[] CastReq { get; set; }
        public Spell(string name, string desc, string spellLvl, bool verbal, bool somatic)
        {
            CastReq = new bool[3];
            Name = name;
            Description = desc;
            CastReq[0] = verbal;
            CastReq[1] = somatic;
            CastReq[2] = false;
            SpellLvl = spellLvl;
        }
        public Spell(string name, string desc, string spellLvl, bool verbal, bool somatic, bool material, string matcomp)
        {
            CastReq = new bool[3];
            Name = name;
            Description = desc;
            CastReq[0] = verbal;
            CastReq[1] = somatic;
            CastReq[2] = material;
            SpellLvl = spellLvl;
            MaterialComponent = matcomp;
        }
    }
}
