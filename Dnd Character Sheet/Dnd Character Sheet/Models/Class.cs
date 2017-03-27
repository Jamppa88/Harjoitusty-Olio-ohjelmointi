using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Character_Sheet.Models
{
    class Class
    {
        public string Name{ get; set; }
        public string HitDice{ get; set; }
        public bool[] SaveProf;
        public List<string> Archetypes;
        public Class(string name, string hitDie, bool strSvProf, bool dexSvProf, bool conSvProf, bool intSvProf, bool wiSsvProf, bool chaSvProf)
        {
            Archetypes = new List<string>();
            SaveProf = new bool[6];
            Name = name;
            HitDice = hitDie;
            SaveProf[0] = strSvProf;
            SaveProf[1] = dexSvProf;
            SaveProf[2] = conSvProf;
            SaveProf[3] = intSvProf;
            SaveProf[4] = wiSsvProf;
            SaveProf[5] = chaSvProf;
        }
        public void AddArchetype(string archetype)
        {
            Archetypes.Add(archetype);
        }
        public override string ToString()
        {
            return Name;
        }
    }
    
}
