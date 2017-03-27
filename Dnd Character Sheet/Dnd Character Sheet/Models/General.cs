using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Character_Sheet.Models
{
    class Trait
    {
        public string Name{ get; set; }
        public string Description{ get; set; }
    }
    public enum alignment { LG,NG,CG,LN,N,CN,LE,NE,CE}
    public enum size { Tiny,Small,Medium,Large,Huge,Gargantuan}
    
    class Datasheet
    {
        public List<Race> Races;
        public Datasheet()
        {
            Races = new List<Race>();
            Races.Add(new Race("Human", 1, 1, 1, 1, 1, 1, 30, size.Medium));
        }
    }
    
}
