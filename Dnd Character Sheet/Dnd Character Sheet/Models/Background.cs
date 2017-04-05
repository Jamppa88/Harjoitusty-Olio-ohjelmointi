using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Character_Sheet.Models
{
    public class Background
    {
        public string Name{ get; set; }
        public bool[] SkillProf;

        public Background(string name, bool acro, bool anihan, bool arca, bool ath, bool dece, bool his, bool insi, bool inti, bool inve, bool medi, bool natu, bool perc, bool perf, bool pers, bool reli, bool slei, bool stea, bool surv)
        {
            SkillProf = new bool[18];
            Name = name;
            SkillProf[0] = acro;
            SkillProf[1] = anihan;
            SkillProf[2] = arca;
            SkillProf[3] = ath;
            SkillProf[4] = dece;
            SkillProf[5] = his;
            SkillProf[6] = insi;
            SkillProf[7] = inti;
            SkillProf[8] = inve;
            SkillProf[9] = medi;
            SkillProf[10] = natu;
            SkillProf[11] = perc;
            SkillProf[12] = perf;
            SkillProf[13] = pers;
            SkillProf[14] = reli;
            SkillProf[15] = slei;
            SkillProf[16] = stea;
            SkillProf[17] = surv;

        }
        public override string ToString()
        {
            return Name;
        }
    }
}
