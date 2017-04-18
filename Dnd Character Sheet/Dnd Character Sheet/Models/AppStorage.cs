using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

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
            StorageFolder insFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder assets = await insFolder.GetFolderAsync("Assets");
            StorageFolder tables = await assets.GetFolderAsync("Tables");

            // Check if need to create tables
            if (await tables.TryGetItemAsync("Classes.xml") == null || await tables.TryGetItemAsync("Races.xml") == null 
                || await tables.TryGetItemAsync("Subraces.xml") == null || await tables.TryGetItemAsync("Backgrounds.xml") == null)
            { Extensions.CreateTables(); }

            // Load .xml-files
            Classes = await Extensions.ReadFromFile<Class>("Classes.xml", "Tables");
            Races = await Extensions.ReadFromFile<Race>("Races.xml", "Tables");
            Subraces = await Extensions.ReadFromFile<Subrace>("Subraces.xml", "Tables");
            Backgrounds = await Extensions.ReadFromFile<Background>("Backgrounds.xml", "Tables");
                
            
            
        }
        public static int GetProfiency()
        {
            if (SelectedCharacter.Level < 5)
                return  2;
            else if (SelectedCharacter.Level < 9)
                return 3;
            else if (SelectedCharacter.Level < 13)
                return 4;
            else if (SelectedCharacter.Level < 17)
                return 5;
            else 
                return 6;
        }

    }
}
