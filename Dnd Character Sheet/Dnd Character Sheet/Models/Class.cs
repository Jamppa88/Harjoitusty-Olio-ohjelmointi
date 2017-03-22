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
        public bool[] SaveProf { get; set; }
        public List<Archetype> Archetypes;
    }
    class Archetype
    {

    }
}
