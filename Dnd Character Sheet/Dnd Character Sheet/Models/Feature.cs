using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Character_Sheet.Models
{
    class Feature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Feature(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
    }
}
