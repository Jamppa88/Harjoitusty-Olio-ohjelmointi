using Dnd_Character_Sheet.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Windows.Storage;


namespace Dnd_Character_Sheet.ViewModels
{
    class CharacterViewModel
    {
        public ObservableCollection<Character> Characters { get; set; }
        public CharacterViewModel()
        {
            Characters = new ObservableCollection<Character>();
             GetCharacters();
            
        }
        async public void GetCharacters()
        {
            StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder assets = await folder.GetFolderAsync("Assets");
            StorageFolder chars = await assets.GetFolderAsync("Characters");
            var x = await chars.GetFilesAsync();
            foreach (var i in x)
            {
                string a = await FileIO.ReadTextAsync(i);
                Character b = a.FromXml<Character>();
                this.Characters.Add(b);
            }
        }
    }
}
