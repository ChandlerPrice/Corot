using Corot.Events;
using Corot.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Corot.Research;

namespace Corot
{
    //TODO
    /*
     * Fullscreen
     * Remove the Debug Console on launch
     */ 

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Game game;
        BaseDefense baseDefence = new BaseDefense();
        //Corot.People.People person = new Corot.People.People();
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
            game.day = 1;
            game.food = 5;
            for (int i=0;i<4; i++)
            {
                Corot.People.People person = new Corot.People.People();
                Game.townPopulation.Add(person);
            }
            UpdatePeopleList();

            textBox.Text = ($"Day # {game.day}\nFood # {game.food}\nPopulation # {game.population}");
        }

        private void UpdatePeopleList()
        {
            peopleListBox.Items.Clear();
            for (int i=0;i < Game.townPopulation.Count; i++)
            {
                peopleListBox.Items.Add($"[{i+1}] {Game.townPopulation[i].name}");
            }
            game.population = Game.townPopulation.Count();
        }



        public void NextDay(object sender, RoutedEventArgs e)
        {
            UpdatePeopleList();
            countPeople();
            if (game.population <= 0)
            {
                System.Windows.Application.Current.Shutdown();
            }
            //Update Day
            game.day += 1;
            System.Diagnostics.Debug.WriteLine($"Day {game.day}\n~~~~~~~\n");
            var calculateDanger = baseDefence.calculateDefense();
            setResearch();
            game.Research();
            System.Diagnostics.Debug.WriteLine($"Research points: {Corot.Research.Research.researchPoints}");
            System.Diagnostics.Debug.WriteLine($"Required research: {Corot.Research.Research.maxResearch}");

            //Call random events
            outputDisplay.Text = game.DailyEvent();
            Food();
            countPeople();
            UpdatePeopleList();
            textBox.Text = ($"Day # {game.day}\nFood # {game.food}\nPopulation # {game.population}\nDanger: {calculateDanger}");
        }

        public void Exit(object sender, RoutedEventArgs e)
        {
            /*
            MESSAGE BOX ASK TO CLOSE

            var result = MessageBox.Show("Your progress will not be saved!", "ARE YOU SURE YOU WANT TO EXIT?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)    
            {
                Close();
            }
             */
            System.Windows.Application.Current.Shutdown();
        }

        public void countPeople()
        {
            game.population = Game.townPopulation.Count();
        }

        public void Food()
        {
            int starveChance;
            game.population = Game.townPopulation.Count();
            game.food -= game.population;
            if (game.food < 0 )
            {
                outputDisplay.Text += ("\n\nThe town is starving");
                for (int i = 0; i < Game.townPopulation.Count; i++)
                {
                    starveChance = random.Next(10);
                    if (starveChance == 1)
                    {
                        outputDisplay.Text += ($"\nDied: {Game.townPopulation[i].name}");
                    Game.townPopulation.RemoveAt(i);

                    }
                }
                game.food = 0;
            }
        }

        public void setResearch()
        {
            Corot.Research.Research.researchPoints = 0;

            for (int i = 0; i < Game.townPopulation.Count; i++)
            {
                if (Game.townPopulation[i].job == Corot.People.Jobs.guardingWorkers.ToString())
                {
                    Corot.People.Jobs.scienceWorkers.Add(Game.townPopulation[i]);
                }
            }
        }
        private void peopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (peopleListBox.SelectedItem == null)
            {
                outputDisplay.Text = "";
            }
            else
            {
                int index = int.Parse(peopleListBox.SelectedIndex.ToString());
                outputDisplay.Text = $"Name: {Game.townPopulation[index].name}\n" +
                    $"Combat: {Game.townPopulation[index].combat}\n" +
                    $"Engineering: {Game.townPopulation[index].engineering}\n" +
                    $"Medical: {Game.townPopulation[index].medical}\n" +
                    $"Scavenging: {Game.townPopulation[index].scavenging}\n" +
                    $"Leadership: {Game.townPopulation[index].leadership}\n";
            }
        }
        private void ResearchListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            game.Research();
            if (ResearchListBox.SelectedItem == null)
            {
                outputDisplay.Text = "";
            }
            else
            {
                int index = int.Parse(ResearchListBox.SelectedIndex.ToString());
                string test = ((ComboBoxItem)ResearchListBox.SelectedItem).Content.ToString();
                int trim = int.Parse(test.Substring(1,1));
                outputDisplay.Text = $"{test.Substring(4)} Technology selected";

                switch (trim)
                {
                    case 1:
                        Corot.Research.Research.activeResearch = "bunkBeds";
                        outputDisplay.Text += $"\n {Corot.Research.Research.researchPoints} | {Corot.Research.Research.maxResearch}";
                        break;
                    case 2:
                        Corot.Research.Research.activeResearch = "fortifyWalls";
                        outputDisplay.Text += $"\n {Corot.Research.Research.researchPoints} | {Corot.Research.Research.maxResearch}";
                        break;
                    case 3:
                        Corot.Research.Research.activeResearch = "pesticides";
                        outputDisplay.Text += $"\n {Corot.Research.Research.researchPoints} | {Corot.Research.Research.maxResearch}";
                        break;
                    case 4:
                        Corot.Research.Research.activeResearch = "zombieVitals";
                        outputDisplay.Text += $"\n {Corot.Research.Research.researchPoints} | {Corot.Research.Research.maxResearch}";
                        break;
                    case 5:
                        Corot.Research.Research.activeResearch = "headshot";
                        outputDisplay.Text += $"\n {Corot.Research.Research.researchPoints} | {Corot.Research.Research.maxResearch}";
                        break;
                    case 6:
                        Corot.Research.Research.activeResearch = "antivenom";
                        outputDisplay.Text += $"\n {Corot.Research.Research.researchPoints} | {Corot.Research.Research.maxResearch}";
                        break;
                    case 7:
                        Corot.Research.Research.activeResearch = "signs";
                        outputDisplay.Text += $"\n {Corot.Research.Research.researchPoints} | {Corot.Research.Research.maxResearch}";
                        break;
                    case 8:
                        Corot.Research.Research.activeResearch = "diplomacy";
                        outputDisplay.Text += $"\n {Corot.Research.Research.researchPoints} | {Corot.Research.Research.maxResearch}";
                        break;
                    case 9:
                        Corot.Research.Research.activeResearch = "radio";
                        outputDisplay.Text += $"\n {Corot.Research.Research.researchPoints} | {Corot.Research.Research.maxResearch}";
                        break;
                    default:
                        break;
                }
            }
        }

        private void creditsHeader_Click(object sender, RoutedEventArgs e)
        {
            Credits credits = new Credits();
            credits = new Credits();
            credits.Show();
        }

        private void settingsHeader_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
