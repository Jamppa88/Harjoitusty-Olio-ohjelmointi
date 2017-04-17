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
            StorageFolder insFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder assets = await insFolder.GetFolderAsync("Assets");
            await assets.
        }

    }
}
