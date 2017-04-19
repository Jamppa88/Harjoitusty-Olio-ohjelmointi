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

using Dnd_Character_Sheet.Models;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dnd_Character_Sheet.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CharacterPage : Page
    {
        public CharacterPage()
        {
            this.InitializeComponent();
            InitializeCharacter();
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        private void InitializeCharacter()
        {
            AppStorage.SelectedCharacter.UpdateAbiMod();
            AppStorage.SelectedCharacter.SetHPMax();
            var temp = AppStorage.SelectedCharacter;
            
            txtName.Text = temp.Name;
            txtCRL.Text = temp.Race + " " + temp.Class + " " + temp.Level;
            // Ability Scores
            txbStrScore.Text = temp.AbiScore[0].ToString();
            txbDexScore.Text = temp.AbiScore[1].ToString();
            txbConScore.Text = temp.AbiScore[2].ToString();
            txbIntScore.Text = temp.AbiScore[3].ToString();
            txbWisScore.Text = temp.AbiScore[4].ToString();
            txbChaScore.Text = temp.AbiScore[5].ToString();
            // Modifiers
            txbStrMod.Text = temp.Abimod[0].ToString();
            txbDexMod.Text = temp.Abimod[1].ToString();
            txbConMod.Text = temp.Abimod[2].ToString();
            txbIntMod.Text = temp.Abimod[3].ToString();
            txbWisMod.Text = temp.Abimod[4].ToString();
            txbChaMod.Text = temp.Abimod[5].ToString();
            // Saves
            cbStrProf.IsChecked = temp.Saves[0];
            cbDexProf.IsChecked = temp.Saves[1];
            cbConProf.IsChecked = temp.Saves[2];
            cbIntProf.IsChecked = temp.Saves[3];
            cbWisProf.IsChecked = temp.Saves[4];
            cbChaProf.IsChecked = temp.Saves[5];
            // Skills
            cbAcroProf.IsChecked = temp.SkillProf[0];
            cbAnimProf.IsChecked = temp.SkillProf[1];
            cbArcaProf.IsChecked = temp.SkillProf[2];
            cbAthlProf.IsChecked = temp.SkillProf[3];
            cbDeceProf.IsChecked = temp.SkillProf[4];
            cbHistProf.IsChecked = temp.SkillProf[5];
            cbInsiProf.IsChecked = temp.SkillProf[6];
            cbIntiProf.IsChecked = temp.SkillProf[7];
            cbInveProf.IsChecked = temp.SkillProf[8];
            cbMediProf.IsChecked = temp.SkillProf[9];
            cbNatuProf.IsChecked = temp.SkillProf[10];
            cbPercProf.IsChecked = temp.SkillProf[11];
            cbPerfProf.IsChecked = temp.SkillProf[12];
            cbPersProf.IsChecked = temp.SkillProf[13];
            cbReliProf.IsChecked = temp.SkillProf[14];
            cbSleiProf.IsChecked = temp.SkillProf[15];
            cbSteaProf.IsChecked = temp.SkillProf[16];
            cbSurvProf.IsChecked = temp.SkillProf[17];
            // Health
            txbHealthMax.Text = temp.HealthMax.ToString();
            txbHealthCurr.Text = temp.HealthCurr.ToString();
            txbHealthTemp.Text = temp.HealthTemp.ToString();
            // Profiency bonus and Initiative
            txbProficiency.Text = AppStorage.GetProfiency().ToString();
            txbInitiative.Text = temp.Abimod[1].ToString();
            // Save and Skill Calculations
            CalcSavesAndSkills();

        }
        
        private void CalcSavesAndSkills()
        {
            int i = 0;
            // Calculation of Saving Throws
            foreach (RelativePanel rp in rpSaves.Children.OfType<RelativePanel>())
            {
                if ((bool)rp.Children.OfType<CheckBox>().First().IsChecked)
                {
                    rp.Children.OfType<TextBox>().First().Text = (AppStorage.SelectedCharacter.Abimod[i] + AppStorage.GetProfiency()).ToString();
                    i++;
                }
                else
                {
                    rp.Children.OfType<TextBox>().First().Text = AppStorage.SelectedCharacter.Abimod[i].ToString();
                    i++;
                }
                
            }
            
            // Calculation of Skills
            foreach (RelativePanel rp in rpSkills.Children.OfType<RelativePanel>())
            {
                if ((bool)rp.Children.OfType<CheckBox>().First().IsChecked)
                {
                    rp.Children.OfType<TextBox>().First().Text = (GetAppropriateMod(rp.Children.OfType<TextBlock>().First()) + AppStorage.GetProfiency()).ToString();
                    
                }
                else
                {
                    rp.Children.OfType<TextBox>().First().Text = GetAppropriateMod(rp.Children.OfType<TextBlock>().First()).ToString();
                    
                }
            }
        }
        private int GetAppropriateMod(TextBlock txt) // Selecting appropriate modifier for a skill
        {
            if (txt.Text.Contains("Str"))
                return AppStorage.SelectedCharacter.Abimod[0];
            else if (txt.Text.Contains("Dex"))
                return AppStorage.SelectedCharacter.Abimod[1];
            else if (txt.Text.Contains("Con"))
                return AppStorage.SelectedCharacter.Abimod[2];
            else if (txt.Text.Contains("Int"))
                return AppStorage.SelectedCharacter.Abimod[3];
            else if (txt.Text.Contains("Wis"))
                return AppStorage.SelectedCharacter.Abimod[4];
            else if (txt.Text.Contains("Cha"))
                return AppStorage.SelectedCharacter.Abimod[5];
            else
                return 0;

        }
    }
}
