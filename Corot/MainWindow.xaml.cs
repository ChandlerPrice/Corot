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

            MenuItem newExistMenuItem = (MenuItem)this.populationHeader;

            newExistMenuItem.Items.Clear();

            for (int i = 0; i < Game.townPopulation.Count(); i++)
            {
                MenuItem newMenuItem2 = new MenuItem();
                newMenuItem2.Header = Game.townPopulation[i].name;
                newExistMenuItem.Items.Add(newMenuItem2);
            }

            textBox.Text = ($"Day # {game.day}\nFood # {game.food}\nPopulation # {game.population}");
        }

        private void UpdatePeopleList()
        {
            peopleListBox.Items.Clear();
            for (int i=0;i < Game.townPopulation.Count; i++)
            {
                peopleListBox.Items.Add(Game.townPopulation[i].name);
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
            //game.DailyEvent();
            game.day += 1;
            System.Diagnostics.Debug.WriteLine($"Day {game.day}\n~~~~~~~\n");
            baseDefence.calculateDefense();
            setResearch();
            game.Research();
            System.Diagnostics.Debug.WriteLine($"Research points: {Corot.Research.Research.researchPoints}");
            System.Diagnostics.Debug.WriteLine($"Required research: {Corot.Research.Research.maxResearch}");
            Food();
            countPeople();
            MenuItem newExistMenuItem = (MenuItem)this.populationHeader;

            newExistMenuItem.Items.Clear();

            for (int i = 0; i < Game.townPopulation.Count(); i++)
            {
                MenuItem newMenuItem2 = new MenuItem();
                newMenuItem2.Header = Game.townPopulation[i].name;
                newExistMenuItem.Items.Add(newMenuItem2);
            }

            //Call random events
            outputDisplay.Text = game.DailyEvent();
            countPeople();
            UpdatePeopleList();
            textBox.Text = ($"Day # {game.day}\nFood # {game.food}\nPopulation # {game.population}");
            foodHeader.Header = ($"Food #{game.food}");
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
            populationHeader.Header = ($"Population #{game.population}");
        }

        public void Food()
        {
            int starveChance;
            game.population = Game.townPopulation.Count();
            game.food -= game.population;
            if (game.food < 0 )
            {
                System.Diagnostics.Debug.WriteLine("The town is starving, people are going to die from your incompetence (10% per person)");
                for (int i = 0; i < Game.townPopulation.Count; i++)
                {
                    starveChance = random.Next(10);
                    if (starveChance == 1)
                    {
                    System.Diagnostics.Debug.WriteLine($"Died: {i}");
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
                if (Game.townPopulation[i].idle)
                {
                    Corot.People.Jobs.scienceWorkers.Add(Game.townPopulation[i]);
                }
            }
        }


        private void zombieVitalClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Zombie Vitals");
            Corot.Research.Research.activeResearch = "zombieVitals";
        }

        private void headshotClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Headshot");
            Corot.Research.Research.activeResearch = "headshot";
        }

        private void antiVenomClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Antivenom");
            Corot.Research.Research.activeResearch = "antivenom";
        }

        private void signsClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Signs");
            Corot.Research.Research.activeResearch = "signs";
        }

        private void diplomacyClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Diplomacy");
            Corot.Research.Research.activeResearch = "diplomacy";
        }

        private void radioClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Radio");
            Corot.Research.Research.activeResearch = "radio";
        }

        private void bunkBedsClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Bunk Beds");
            Corot.Research.Research.activeResearch = "bunkBeds";
        }

        private void pesticidesClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Pesticides");
            Corot.Research.Research.activeResearch = "pesticides";
        }

        private void fortifyWallsClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Fortify Walls");
            Corot.Research.Research.activeResearch = "fortifyWalls";
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
    }
}
