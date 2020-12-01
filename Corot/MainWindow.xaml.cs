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
            for (int i=0;i<4; i++)
            {
                Corot.People.People person = new Corot.People.People();
                Game.townPopulation.Add(person);
            }
            game.population = Game.townPopulation.Count();
            game.food = 5;

            MenuItem newExistMenuItem = (MenuItem)this.populationHeader;

            newExistMenuItem.Items.Clear();

            for (int i = 0; i < Game.townPopulation.Count(); i++)
            {
                MenuItem newMenuItem2 = new MenuItem();
                newMenuItem2.Header = Game.townPopulation[i].name;
                newExistMenuItem.Items.Add(newMenuItem2);
            }

        }

        public void NextDay(object sender, RoutedEventArgs e)
        {
            countPeople();
            if (game.population <= 0)
            {
                Close();
            }
            //Update Day
            game.DailyEvent();
            System.Diagnostics.Debug.WriteLine($"Day {game.day + 1}\n~~~~~~~\n");
            game.day += 1;
            baseDefence.calculateDefense();
            setResearch();
            game.Research();
            System.Diagnostics.Debug.WriteLine($"Research points: {Corot.Research.Research.researchPoints}");
            System.Diagnostics.Debug.WriteLine($"Required research: {Corot.Research.Research.maxResearch}");
            Food();
            Population();
            MenuItem newExistMenuItem = (MenuItem)this.populationHeader;

            newExistMenuItem.Items.Clear();

            for (int i = 0; i < Game.townPopulation.Count(); i++)
            {
                MenuItem newMenuItem2 = new MenuItem();
                newMenuItem2.Header = Game.townPopulation[i].name;
                newExistMenuItem.Items.Add(newMenuItem2);
            }
            countPeople();
            dayHeader.Header = ($"Day #{game.day}");
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
            Close();
        }

        //Suppost to be a list of the people in the town
        public void Population()
        {
            for (int i=0; i <= game.population; i++)
            {
                Game.townPopulation.Count();
            }

            game.population = Game.townPopulation.Count();
            System.Diagnostics.Debug.WriteLine($"Population: {game.population}");
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

    }
}
