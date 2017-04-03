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
    public sealed partial class Creation : Page
    {
        public Creation()
        {
            this.InitializeComponent();
            InitializeDemo();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
            
        }
        private void InitializeDemo()
        {
            // Demo rodut
            List<Race> Races = new List<Race>();
            Race race = new Race("Human", 1, 1, 1, 1, 1, 1, 30, size.Medium, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
            Races.Add(race);
            race = new Race("Dwarf", 0, 0, 2, 0, 0, 0, 25, size.Medium, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false);
            race.AddSubrace(new Subrace("Mountain Dwarf", 2, 0, 2, 0, 0, 0));
            race.AddSubrace(new Subrace("Hill Dwarf", 0, 0, 2, 0, 1, 0));
            Races.Add(race);
            cmbRace.ItemsSource = Races;
            // Demo luokat
            List<Class> Classes = new List<Class>();
            Class cls = new Class("Fighter", "d10", true, false, true, false, false, false);
            cls.AddArchetype("Champion");
            Classes.Add(cls);
            cls = new Class("Cleric", "d8", false, false, false, false, true, true);
            cls.AddArchetype("Life");
            Classes.Add(cls);
            cmbClass.ItemsSource = Classes;
            // Demo Backgroundit
            List<Background> Backgrounds = new List<Background>();
            Background bck = new Background("Acolyte", false, false, false, false, false, false, true, false,false,false,false,false,false, false, true, false, false, false);
            Backgrounds.Add(bck);
            bck = new Background("Criminal", false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, true, false);
            Backgrounds.Add(bck);
            cmbBackground.ItemsSource = Backgrounds;
            // Muut
            List<alignment> ali = new List<alignment>();
            ali.Add(alignment.LG); ali.Add(alignment.NG); ali.Add(alignment.CG); ali.Add(alignment.LN); ali.Add(alignment.N); ali.Add(alignment.CN); ali.Add(alignment.LE); ali.Add(alignment.NE); ali.Add(alignment.CE);
            cmbAlignment.ItemsSource = ali;
        }
        // Primer for function, Selected a Race
        ComboBox cmbSubrace = new ComboBox();
        private void cmbRace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var temp = (Race)cmbRace.SelectedItem;
            
            if (temp.Subraces.Count != 0)
            {
                cmbSubrace.ItemsSource = temp.Subraces; cmbSubrace.Margin = new Thickness(0, 10, 0, 0);
                cmbSubrace.Width = 350; cmbSubrace.Height = 50; cmbSubrace.FontSize = 30;
                cmbSubrace.SelectionChanged += CmbSubrace_SelectionChanged;
                RelativePanel.SetAlignRightWithPanel(cmbSubrace, true);
                RelativePanel.SetBelow(cmbSubrace, sender);
                rpBasicInfo.Children.Add(cmbSubrace);
                RelativePanel.SetBelow(cmbClass, cmbSubrace);
                RelativePanel.SetBelow(txtClass, cmbSubrace);
                SetLanguages(temp);
            }
            else
            {
                RelativePanel.SetBelow(cmbClass, cmbRace);
                RelativePanel.SetBelow(txtClass, txtRace);
                rpBasicInfo.Children.Remove(cmbSubrace);
                SetAbilityBonuses(temp);
                SetLanguages(temp);
            }
                
           
            
        }

        private void CmbSubrace_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetAbilityBonuses((Subrace)cmbSubrace.SelectedItem);
        }

        // Primer for function, Selected a Class
        ComboBox cmbSubclass = new ComboBox();
        bool clsChanged = false;
        private void cmbClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clsChanged = true;
            var temp = (Class)cmbClass.SelectedItem;
            if (rpBasicInfo.Children.Contains(addClass)) { 
                rpBasicInfo.Children.Remove(addClass);
                rpBasicInfo.Children.Remove(txtLevel); rpBasicInfo.Children.Remove(txbLevel);
                rpBasicInfo.Children.Remove(txtHitPoints); rpBasicInfo.Children.Remove(txbHitPoints);
            }
            rpBasicInfo.Children.Remove(cmbSubclass);
            cmbSubclass.SelectionChanged += CmbSubclass_SelectionChanged; ;
            cmbSubclass.ItemsSource = temp.Archetypes; cmbSubclass.Margin = new Thickness(0, 10, 0, 0);
            cmbSubclass.Width = 350; cmbSubclass.Height = 50; cmbSubclass.FontSize = 30;
            RelativePanel.SetAlignRightWithPanel(cmbSubclass, true);
            RelativePanel.SetBelow(cmbSubclass, sender);
            rpBasicInfo.Children.Add(cmbSubclass);

            // Set Saving Throws
            rbStr.IsChecked = temp.SaveProf[0];
            rbDex.IsChecked = temp.SaveProf[1];
            rbCon.IsChecked = temp.SaveProf[2];
            rbInt.IsChecked = temp.SaveProf[3];
            rbWis.IsChecked = temp.SaveProf[4];
            rbCha.IsChecked = temp.SaveProf[5];
            clsChanged = false;
        }
        // Primer for function, Selected a Subclass
        TextBox txbLevel = new TextBox();
        TextBox txbHitPoints = new TextBox();
        TextBlock txtLevel = new TextBlock();
        TextBlock txtHitPoints = new TextBlock();
        Button addClass = new Button();
        private void CmbSubclass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!clsChanged) { 
                var temp = (Class)cmbClass.SelectedItem;

                // Define hitPoints
                txtHitPoints.Text = "HP:";
                txtHitPoints.Margin = new Thickness(10, 10, 0, 0);
                txtHitPoints.Width = 50; txtHitPoints.Height = 40; txtHitPoints.FontSize = 25;
            
                txbHitPoints.PlaceholderText = "1"+temp.HitDice;
                txbHitPoints.Margin = new Thickness(10, 10, 0, 0);
                txbHitPoints.Width = 150; txbHitPoints.Height = 40; txbHitPoints.FontSize = 25;

                RelativePanel.SetAlignRightWithPanel(txbHitPoints, true);
                RelativePanel.SetBelow(txbHitPoints, sender);
                RelativePanel.SetLeftOf(txtHitPoints, txbHitPoints);
                RelativePanel.SetBelow(txtHitPoints, sender);

                // Define level
                txtLevel.Text = "Lvl:";
                txtLevel.Margin = new Thickness(10, 10, 0, 0);
                txtLevel.Width = 50; txtLevel.Height = 40; txtLevel.FontSize = 25;

                txbLevel.Text = "1";
                txbLevel.Margin = new Thickness(10, 10, 0, 0);
                txbLevel.Width = 50; txbLevel.Height = 40; txbLevel.FontSize = 25;

                RelativePanel.SetLeftOf(txbLevel, txtHitPoints);
                RelativePanel.SetBelow(txbLevel, sender);
                RelativePanel.SetLeftOf(txtLevel, txbLevel);
                RelativePanel.SetBelow(txtLevel, sender);

                // Define AddClassButton
                addClass.Content = "Add Class";
                addClass.Click += AddClass_Click;
                addClass.Width = 150; addClass.Height = 50; addClass.Margin = new Thickness(0,10,100,0);
                addClass.FontSize = 20;
                RelativePanel.SetBelow(addClass, txbHitPoints); RelativePanel.SetAlignRightWithPanel(addClass, true);

                // Create entities
                if (!rpBasicInfo.Children.Contains(txbHitPoints)) { 
                    rpBasicInfo.Children.Add(txbHitPoints);
                    rpBasicInfo.Children.Add(txtHitPoints);
                    rpBasicInfo.Children.Add(txbLevel); rpBasicInfo.Children.Add(txtLevel);
                    rpBasicInfo.Children.Add(addClass);
                }
            }
        }
        bool MessageCheck = false;
        private async void AddClass_Click(object sender, RoutedEventArgs e)
        {
            if (!MessageCheck) {
                MessageCheck = true;
                var temp = new Windows.UI.Popups.MessageDialog("Not implemented yet, sorry :(");
                await temp.ShowAsync();
                MessageCheck = false;
            }
        }

        private void SetAbilityBonuses(Race race)
        {
            txbStrRac.Text = race.AbiBonus[0].ToString();
            txbDexRac.Text = race.AbiBonus[1].ToString();
            txbConRac.Text = race.AbiBonus[2].ToString();
            txbIntRac.Text = race.AbiBonus[3].ToString();
            txbWisRac.Text = race.AbiBonus[4].ToString();
            txbChaRac.Text = race.AbiBonus[5].ToString();
        }
        private void SetAbilityBonuses(Subrace race)
        {
            txbStrRac.Text = race.AbiBonus[0].ToString();
            txbDexRac.Text = race.AbiBonus[1].ToString();
            txbConRac.Text = race.AbiBonus[2].ToString();
            txbIntRac.Text = race.AbiBonus[3].ToString();
            txbWisRac.Text = race.AbiBonus[4].ToString();
            txbChaRac.Text = race.AbiBonus[5].ToString();
        }
        private void SetLanguages(Race race)
        {
            cbCommon.IsChecked = race.Languages[0];
            cbDwarwish.IsChecked = race.Languages[1];
            cbElvish.IsChecked = race.Languages[2];
            cbGiant.IsChecked = race.Languages[3];
            cbGnomish.IsChecked = race.Languages[4];
            cbGoblin.IsChecked = race.Languages[5];
            cbHalfling.IsChecked = race.Languages[6];
            cbOrc.IsChecked = race.Languages[7];
            cbAbyssal.IsChecked = race.Languages[8];
            cbCelestial.IsChecked = race.Languages[9];
            cbDraconic.IsChecked = race.Languages[10];
            cbDeepSpeech.IsChecked = race.Languages[11];
            cbInfernal.IsChecked = race.Languages[12];
            cbPrimordial.IsChecked = race.Languages[13];
            cbSylvan.IsChecked = race.Languages[14];
            cbUndercommon.IsChecked = race.Languages[15];
        }

        private async void Calc_AbilityScoreTotal(object sender, TextChangedEventArgs e)
        {
            if (txbStrBase.Text != "" && txbDexBase.Text != "" && txbConBase.Text != "" && txbIntBase.Text != "" && txbWisBase.Text != "" && txbChaBase.Text != "")
            { 
                try { 
                    txbStrTot.Text = (int.Parse(txbStrBase.Text) + int.Parse(txbStrRac.Text)).ToString();
                    txbDexTot.Text = (int.Parse(txbDexBase.Text) + int.Parse(txbDexRac.Text)).ToString();
                    txbConTot.Text = (int.Parse(txbConBase.Text) + int.Parse(txbConRac.Text)).ToString();
                    txbIntTot.Text = (int.Parse(txbIntBase.Text) + int.Parse(txbIntRac.Text)).ToString();
                    txbWisTot.Text = (int.Parse(txbWisBase.Text) + int.Parse(txbWisRac.Text)).ToString();
                    txbChaTot.Text = (int.Parse(txbChaBase.Text) + int.Parse(txbChaRac.Text)).ToString();
                    Calc_AbilityMod();
                } catch
                {
                    if (cmbRace.SelectedItem == null){ }
                    else
                    {
                        var temp = new Windows.UI.Popups.MessageDialog("Try numbers...");
                        await temp.ShowAsync();
                    }
                    

                }
            }
        }

        private void Calc_AbilityMod()
        {
            try
            {
                

                if (int.Parse(txbStrTot.Text) >= 10)
                    txbStrMod.Text = ((int.Parse(txbStrTot.Text) - 10) / 2).ToString();
                else
                    txbStrMod.Text = ((int.Parse(txbStrTot.Text) - 11) / 2 ).ToString();
                if (int.Parse(txbDexTot.Text) >= 10)
                    txbDexMod.Text = ((int.Parse(txbDexTot.Text) - 10) / 2).ToString();
                else
                    txbDexMod.Text = ((int.Parse(txbDexTot.Text) - 11) / 2 ).ToString();
                if (int.Parse(txbConTot.Text) >= 10)
                    txbConMod.Text = ((int.Parse(txbConTot.Text) - 10) / 2).ToString();
                else
                    txbConMod.Text = ((int.Parse(txbConTot.Text) - 11) / 2).ToString();
                if (int.Parse(txbIntTot.Text) >= 10)
                    txbIntMod.Text = ((int.Parse(txbIntTot.Text) - 10) / 2).ToString();
                else
                    txbIntMod.Text = ((int.Parse(txbIntTot.Text) - 11) / 2).ToString();
                if (int.Parse(txbWisTot.Text) >= 10)
                    txbWisMod.Text = ((int.Parse(txbWisTot.Text) - 10) / 2).ToString();
                else
                    txbWisMod.Text = ((int.Parse(txbWisTot.Text) - 11) / 2).ToString();
                if (int.Parse(txbChaTot.Text) >= 10)
                    txbChaMod.Text = ((int.Parse(txbChaTot.Text) - 10) / 2).ToString();
                else
                    txbChaMod.Text = ((int.Parse(txbChaTot.Text) - 11) / 2).ToString();





            } catch 
            {
                
            }
        }

        private void cmbBackground_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Background temp = (Background)cmbBackground.SelectedItem;
            cbAcrobatics.IsChecked = temp.SkillProf[0];
            cbAnimalHandling.IsChecked = temp.SkillProf[1];
            cbArcana.IsChecked = temp.SkillProf[2];
            cbAthletics.IsChecked = temp.SkillProf[3];
            cbDeception.IsChecked = temp.SkillProf[4];
            cbHistory.IsChecked = temp.SkillProf[5];
            cbInsight.IsChecked = temp.SkillProf[6];
            cbIntimidation.IsChecked = temp.SkillProf[7];
            cbInvestigation.IsChecked = temp.SkillProf[8];
            cbMedicine.IsChecked = temp.SkillProf[9];
            cbNature.IsChecked = temp.SkillProf[10];
            cbPerception.IsChecked = temp.SkillProf[11];
            cbPerformance.IsChecked = temp.SkillProf[12];
            cbPersuation.IsChecked = temp.SkillProf[13];
            cbReligion.IsChecked = temp.SkillProf[14];
            cbSleightOfHand.IsChecked = temp.SkillProf[15];
            cbStealth.IsChecked = temp.SkillProf[16];
            cbSurvival.IsChecked = temp.SkillProf[17];
        }

        private async void bSave_Click(object sender, RoutedEventArgs e)
        {
            if (txbCharName.Text == null || txbCharName.Text == "")
            {
                var temp = new Windows.UI.Popups.MessageDialog("Enter a Name!!!");
                await temp.ShowAsync();
            }
            else if (cmbRace.SelectedItem == null)
            {
                var temp = new Windows.UI.Popups.MessageDialog("Choose a Race!!!");
                await temp.ShowAsync();
            }
            else if (cmbSubclass.SelectedItem == null)
            {
                var temp = new Windows.UI.Popups.MessageDialog("Choose a Class!!!");
                await temp.ShowAsync();
            }
            else if (txbHitPoints.Text == null)
            {
                var temp = new Windows.UI.Popups.MessageDialog("Determine hit points!!!");
                await temp.ShowAsync();
            }
            else
            {
                Character tmp = new Character();
                tmp.Race = (Race)cmbRace.SelectedItem;
                tmp.Subrace = (Subrace)cmbSubrace.SelectedItem;
                tmp.Name = txbCharName.Text;
                tmp.Class = (Class)cmbClass.SelectedItem;
                tmp.Archetype = (string)cmbSubclass.SelectedItem;
                tmp.Background = (Background)cmbBackground.SelectedItem;
                tmp.Level = int.Parse(txbLevel.Text);
                tmp.Speed = ((Race)cmbRace.SelectedItem).BaseSpeed;
                // Set skill profiencies
                int i = 0;
                foreach (CheckBox cb in rpSkills.Children.OfType<CheckBox>())
                {
                    
                    tmp.SkillProf[i] = (bool)cb.IsChecked;
                    i++;
                }
                // set ability scores
                tmp.AbiScore[0] = int.Parse(txbStrTot.Text);
                tmp.AbiScore[1] = int.Parse(txbDexTot.Text);
                tmp.AbiScore[2] = int.Parse(txbConTot.Text);
                tmp.AbiScore[3] = int.Parse(txbIntTot.Text);
                tmp.AbiScore[4] = int.Parse(txbWisTot.Text);
                tmp.AbiScore[5] = int.Parse(txbChaTot.Text);
                tmp.UpdateAbiMod();
                // set saves
                i = 0;
                foreach (CheckBox cb in rpSaves.Children.OfType<CheckBox>())
                {
                    tmp.Saves[i] = (bool)cb.IsChecked;
                    i++;
                }
                // Hitpoints
                tmp.HpRolls[0] = int.Parse(txbHitPoints.Text);
                tmp.SetHPMax();
                tmp.HealthCurr = tmp.HealthMax;
                // Set Languages
                i = 0;
                foreach (CheckBox cb in rpLanguages.Children.OfType<CheckBox>())
                {
                    tmp.Languages[i] = (bool)cb.IsChecked;
                    i++;
                }
                // tests
                var temp = new Windows.UI.Popups.MessageDialog(""+ tmp.HealthMax);
                await temp.ShowAsync();
            }
        }
    }
}
