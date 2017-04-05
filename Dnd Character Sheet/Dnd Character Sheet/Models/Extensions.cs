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

        public static async void SaveToFile(this object obj)
        {
            
            XmlSerializer xs = new XmlSerializer(obj.GetType());
            using (StringWriter writer = new StreamWriter())
            {
                xs.Serialize(writer, obj);

            }
            /*if (Directory.Exists(@"Characters\"))
                await Task.Run(() =>File.WriteAllText(@"Characters\" + fileName, content));
            else
            {
                
                await Task.Run(() => File.WriteAllText(@"Characters\" + fileName, content));
            } */   
            

        }

    }
}
