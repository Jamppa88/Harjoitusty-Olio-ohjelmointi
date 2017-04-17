using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnd_Character_Sheet.Models
{
    public static class AppStorage
    {
        public static Character SelectedCharacter { get; set; }
        public static List<Class> Classes { get; set; }
        public static List<Race> Races { get; set; }
        public static List<Subrace> Subraces { get; set; }
        public static List<Background> Backgrounds { get; set; }

        public async static void InitializeStorage()
        {
            Classes = await Extensions.ReadFromFile<Class>("Classes.xml", "Tables");
            Races = await Extensions.ReadFromFile<Race>("Races.xml", "Tables");
            Subraces = await Extensions.ReadFromFile<Subrace>("Subraces.xml", "Tables");
            Backgrounds = await Extensions.ReadFromFile<Background>("Backgrounds.xml", "Tables");
            await Task.Run(() => Extensions.CreateTables());
        }

    }
}
