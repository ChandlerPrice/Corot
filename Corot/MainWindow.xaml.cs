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
        int numOfBuildings;
        int buttonNumber;
        List<Corot.Buildings.Building> buildings = new List<Buildings.Building>();
        List<Button> buttons = new List<Button>();

        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
            ButtonGeneration();
            game.day = 1;
            game.food = 50;
            for (int i=0;i<8; i++)
            {
                Corot.People.People person = new Corot.People.People();
                Game.townPopulation.Add(person);
            }
            UpdatePeopleList();
            Buildings.Building residentialBuilding = new Buildings.Building("residential");
            Buildings.Building defenseBuilding = new Buildings.Building("defense");
            Buildings.Building farmBuilding = new Buildings.Building("Farm");


            buildings.Add(residentialBuilding);
            buildings.Add(defenseBuilding);
            buildings.Add(farmBuilding);


            numOfBuildings = buildings.Count();

            PopulationAdjusting();

            textBox.Text = ($"Day # {game.day}\nFood # {game.food}\nPopulation # {game.population} / {game.MaxPopulation}\nResearch: {Research.Research.researchPoints} | {Research.Research.maxResearch}");
        }

        public void ButtonGeneration()
        {
            for (int column = 0; column <= 10; column++)
            {
                for (int row = 0; row <= 10; row++)
                {
                    Button button = new Button();
                    button.Name = "button" + buttonNumber;
                    buttonNumber++;
                }
            }
        }
        private void UpdatePeopleList()
        {
            peopleListBox.Items.Clear();
            for (int i=0;i < Game.townPopulation.Count; i++)
            {
                var test = Game.townPopulation[i].job;
                string jobValue = Game.townPopulation[i].job.ToString().Substring(0,4);
                peopleListBox.Items.Add($"[{i+1}] {Game.townPopulation[i].name} [{jobValue}]");
            }
            game.population = Game.townPopulation.Count();
        }

        public void BuildingGeneration()
        {
            for (int i = 0; i < buttons.Count(); i++)
            {

            }
        }

        public void NextDay(object sender, RoutedEventArgs e)
        {
            if (game.population > 0)
            {
                jobAssignment.Visibility = Visibility.Hidden;
                jobUI.Visibility = Visibility.Hidden;
                UpdatePeopleList();
                countPeople();
                if (game.population <= 0)
                {
                    System.Windows.Application.Current.Shutdown();
                }
                //Update Day
                game.day += 1;
                var calculateDanger = baseDefence.calculateDefense();
                checkResearch();
                setResearch();
                game.Research();
                checkResearch();

                //Call random events
                outputDisplay.Text = game.DailyEvent();
                Food();
                countPeople();
                UpdatePeopleList();
                textBox.Text = ($"Day # {game.day}\nFood # {game.food}\nPopulation # {game.population} / {game.MaxPopulation}\nDanger: {calculateDanger}\nResearch: {Research.Research.researchPoints} | {Research.Research.maxResearch}");
            }
            else
            {
                //Game Over screen
                System.Windows.Application.Current.Shutdown();
            }
        }

        public void Exit(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Your progress will not be saved!", "ARE YOU SURE YOU WANT TO EXIT?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)    
            {
                this.Close();
                StartWindow win = new StartWindow();
                win.Show();
            }
        }

        public void countPeople()
        {
            game.population = Game.townPopulation.Count();
        }

        public void Food()
        {
            for (int i = 0; i < buildings.Count(); i++)
            {
                if (buildings[i].typeOfBuilding == "Farm")
                {
                    game.food += 10;
                }
            }

            int starveChance;
            game.population = Game.townPopulation.Count();
            game.food -= game.population;
            if (game.food < 0)
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

        public void PopulationAdjusting()
        {
            for (int i = 0; i < buildings.Count(); i++)
            {
                if (buildings[i].typeOfBuilding == "residential")
                {
                    game.MaxPopulation += 10;
                }
            }
        }

        public void checkResearch()
        {
            if (Research.Research.activeResearch == null)
            {
                researchUI.Visibility = Visibility.Visible;
                ResearchListBox.Visibility = Visibility.Visible;
            }
            else
            {
                researchUI.Visibility = Visibility.Hidden;
                ResearchListBox.Visibility = Visibility.Hidden;
            }
        }
      
        public void setResearch()
        {
            Corot.Research.Research.researchPoints = 0;
            for (int i = 0; i < Game.townPopulation.Count; i++)
            {
                if (Game.townPopulation[i].job == Corot.People.People.Jobs.Scientist)
                {
                    Corot.Research.Research.researchPoints += Game.townPopulation[i].engineering;
                }
            }
        }
        private void peopleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (peopleListBox.SelectedItem == null)
            {
                //outputDisplay.Text = "No person was selected";
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
                    jobAssignment.Visibility = Visibility.Visible;
                    jobUI.Visibility = Visibility.Visible;
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

        private void jobAssignment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = int.Parse(peopleListBox.SelectedIndex.ToString());
            string test = ((ComboBoxItem)jobAssignment.SelectedItem).Content.ToString();
            int trim = int.Parse(test.Substring(1, 1));
            outputDisplay.Text = $"{Game.townPopulation[index].name} changed to the {test.Substring(4)} job\n" +
                    $"Name: {Game.townPopulation[index].name}\n" +
                    $"Combat: {Game.townPopulation[index].combat}\n" +
                    $"Engineering: {Game.townPopulation[index].engineering}\n" +
                    $"Medical: {Game.townPopulation[index].medical}\n" +
                    $"Scavenging: {Game.townPopulation[index].scavenging}\n" +
                    $"Leadership: {Game.townPopulation[index].leadership}\n";
            
            switch (trim)
            {
                case 1:
                    Game.townPopulation[index].job = Corot.People.People.Jobs.Guard;
                    break;
                case 2:
                    Game.townPopulation[index].job = Corot.People.People.Jobs.Fighter;
                    break;
                case 3:
                    Game.townPopulation[index].job = Corot.People.People.Jobs.Scavenger;
                    break;
                case 4:
                    Game.townPopulation[index].job = Corot.People.People.Jobs.Farmer;
                    break;
                case 5:
                    Game.townPopulation[index].job = Corot.People.People.Jobs.Scientist;
                    break;
                case 6:
                    Game.townPopulation[index].job = Corot.People.People.Jobs.Scout;
                    break;
                default:
                    break;
            }
            jobAssignment.Visibility = Visibility.Hidden;
            jobUI.Visibility = Visibility.Hidden;
            UpdatePeopleList();
        }
    }
}
