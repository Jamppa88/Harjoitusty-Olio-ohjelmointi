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
using Windows.Storage;

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
        ViewModels.CharacterViewModel chView;
        public MainPage()
        {
            this.InitializeComponent();
            InitializeCharacters();
            AppStorage.InitializeStorage();
            
        }

        private void InitializeCharacters()
        {
            lsvCharacters.DataContext = null;
            chView = new ViewModels.CharacterViewModel();
            lsvCharacters.DataContext = chView.Characters;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Creation));
        }

        

        

        private void txtChr_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var tmp = (RelativePanel)sender;
            txtPuChr.Text = ((TextBlock)tmp.Children[0]).Text;
            txtPuBase.Text = ((TextBlock)((StackPanel)tmp.Children[1]).Children[0]).Text;
            txtPuBase.Text += " " + ((TextBlock)((StackPanel)tmp.Children[1]).Children[1]).Text;
            txtPuBase.Text += " " + ((TextBlock)((StackPanel)tmp.Children[1]).Children[2]).Text;
            ppup.IsOpen = true;
            
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string temp = txtPuChr.Text;
            AppStorage.SelectedCharacter = chView.Characters.Where(x => x.Name == temp).First();
            this.Frame.Navigate(typeof(CharacterPage));
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try { 
                ppup.IsOpen = false;
                StorageFolder appFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                StorageFolder assets = await appFolder.GetFolderAsync("Assets");
                StorageFolder charFolder = await assets.GetFolderAsync("Characters");
                StorageFile deleteThis = await charFolder.GetFileAsync(txtPuChr.Text + ".xml");
                //await deleteThis.MoveAsync(ApplicationData.Current.LocalFolder, "delete_this", NameCollisionOption.ReplaceExisting);
                await deleteThis.DeleteAsync();
                var msg = new Windows.UI.Popups.MessageDialog("Character deleted succesfully.");
                await msg.ShowAsync();
                InitializeCharacters();
            }catch (Exception ex)
            {
                var msg = new Windows.UI.Popups.MessageDialog("Error occured: " + ex.Message);
                await msg.ShowAsync();
            }
        }
    }
}
