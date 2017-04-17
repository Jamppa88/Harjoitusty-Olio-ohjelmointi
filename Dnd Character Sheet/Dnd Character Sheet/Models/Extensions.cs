using System;
using System.Windows;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Dnd_Character_Sheet.Models;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using Windows.Storage;

namespace Dnd_Character_Sheet.Models
{
    public static class Extensions
    {
        public static string ToXml(this object obj)
        {
            XmlSerializer s = new XmlSerializer(obj.GetType());
            using (StringWriter writer = new StringWriter())
            {
                s.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        public static T FromXml<T>(this string data)
        {
            XmlSerializer s = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(data))
            {
                object obj = s.Deserialize(reader);
                return (T)obj;
            }
        }

        public static async void SaveToFile(this string data, string fileName, string folder)
        {
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile saveFile = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(saveFile, data);
                StorageFolder appFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                StorageFolder assets = await appFolder.GetFolderAsync("Assets");
                var destination = await assets.GetFolderAsync(folder);
                await saveFile.MoveAsync(destination, fileName, NameCollisionOption.ReplaceExisting);
            }catch (Exception ex)
            {
                throw ex;
            }
                
          
            
            
            
            

        }
        /// <summary>
        /// Works with Lists of any type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        public static async Task<List<T>> ReadFromFile<T>(string fileName, string folder)
        {
            
            StorageFolder insFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder assets = await insFolder.GetFolderAsync("Assets");
            StorageFolder readFolder = await assets.GetFolderAsync(folder);
            var x = await readFolder.GetFileAsync(fileName);
            string a = await FileIO.ReadTextAsync(x);
            List<T> obj = a.FromXml<List<T>>();
            return obj;
                
            
        }
        public static async void CreateTables()
        {
            /// Getting Assets-folder
            
            /// Getting local folder
            

            /// Prime instances
            // Demo rodut
            List<Subrace> Subraces;
            List<Race> Races = new List<Race>();
            Race race = new Race("Human", 1, 1, 1, 1, 1, 1, 30, size.Medium, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
            Races.Add(race);
            race = new Race("Dwarf", 0, 0, 2, 0, 0, 0, 25, size.Medium, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
            Subraces = new List<Subrace>();
            Subraces.Add(new Subrace("Mountain Dwarf", 2, 0, 2, 0, 0, 0));
            Subraces.Add(new Subrace("Hill Dwarf", 0, 0, 2, 0, 1, 0));
            race.AddSubrace(new Subrace("Mountain Dwarf", 2, 0, 2, 0, 0, 0));
            race.AddSubrace(new Subrace("Hill Dwarf", 0, 0, 2, 0, 1, 0));
            Races.Add(race);

            

            string temp = Races.ToXml();
            await Task.Run(() => temp.SaveToFile("Races.xml", "Tables"));
            temp = Subraces.ToXml();
            await Task.Run(() => temp.SaveToFile("Subraces.xml", "Tables"));

            // Demo luokat 
            List<Class> Classes = new List<Class>();

            Class cls = new Class("Fighter", "d10", true, false, true, false, false, false);
            cls.AddArchetype("Champion");
            Classes.Add(cls);
            cls = new Class("Cleric", "d8", false, false, false, false, true, true);
            cls.AddArchetype("Life");
            Classes.Add(cls);

            temp = Classes.ToXml();
            await Task.Run(() => temp.SaveToFile("Classes.xml", "Tables"));

            // Demo Backgroundit
            List<Background> Backgrounds = new List<Background>();
            Background bck = new Background("Acolyte", false, false, false, false, false, false, true, false,false,false,false,false,false, false, true, false, false, false);
            Backgrounds.Add(bck);
            bck = new Background("Criminal", false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, true, false);
            Backgrounds.Add(bck);

            

            temp = Backgrounds.ToXml();
            await Task.Run(() => temp.SaveToFile("Backgrounds.xml", "Tables"));

            

        }

    }
}
