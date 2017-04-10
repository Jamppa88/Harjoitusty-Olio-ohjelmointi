using System;
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
using Dnd_Character_Sheet.Views;
using Dnd_Character_Sheet.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Dnd_Character_Sheet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Character> chrs;
        ViewModels.CharacterViewModel chView;
        public MainPage()
        {
            this.InitializeComponent();
            chView = new ViewModels.CharacterViewModel();
            Characters.DataContext = chView.Characters;
            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Creation));
        }

        
    }
}
