using Corot.Events;
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
        People person = new People();
        

        public MainWindow()
        {
            InitializeComponent();
            game = new Game();

            game.day = 1;
            Game.townPopulation.Add(person);
            Game.townPopulation.Add(person);
            Game.townPopulation.Add(person);
            Game.townPopulation.Add(person);
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
            //Update Day
            System.Diagnostics.Debug.WriteLine($"Day {game.day}\n~~~~~~~\n");
            game.day = game.day + 1;
            dayHeader.Header = ("Day #" + game.day);
            foodHeader.Header = ("Food #" + game.food);
            baseDefence.calculateDefense();
            setResearch();
            Research();

            Population();
            populationHeader.Header = ("Population #" + Game.townPopulation.Count());
            MenuItem newExistMenuItem = (MenuItem)this.populationHeader;

            newExistMenuItem.Items.Clear();

            for (int i = 0; i < Game.townPopulation.Count(); i++)
            {
                MenuItem newMenuItem2 = new MenuItem();
                newMenuItem2.Header = Game.townPopulation[i].name;
                newExistMenuItem.Items.Add(newMenuItem2);
            }

            //Call random events
            game.DailyEvent();

            //Remove food
            if (game.food < Game.townPopulation.Count())
            {

            }
            else
            {
                game.food -= Game.townPopulation.Count();
            }

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
                Game.townPopulation.Add(person);
            }

            game.population = Game.townPopulation.Count();
            System.Diagnostics.Debug.WriteLine($"Population: {Game.townPopulation}");
        }

        public void setResearch()
        {
            Game.researchPoints = 0;

            for (int i = 0; i < Game.townPopulation.Count; i++)
            {
                if (Game.townPopulation[i].idle)
                {
                    Game.scienceWorkers.Add(Game.townPopulation[i]);
                }
            }
        }

        public void Research()
        {
            switch (Game.activeResearch)
            {
                case "zombieVitals":
                    if (Game.maxResearch > 0)
                    {
                    Game.maxResearch = -Game.researchPoints;
                    }
                    else
                    {
                        bool test = Corot.Research.Research.zombieVitalsComplete = true;
                    }
                    break;
                case "headshot":
                    if (Game.maxResearch > 0)
                    {
                        Game.maxResearch = -Game.researchPoints;
                    }
                    else
                    {
                        bool test = Corot.Research.Research.headshotComplete = true;
                    }
                    break;
                case "antivenom":
                    if (Game.maxResearch > 0)
                    {
                        Game.maxResearch = -Game.researchPoints;
                    }
                    else
                    {
                        bool test = Corot.Research.Research.antiVenomComplete = true;
                    }
                    break;
                case "signs":
                    if (Game.maxResearch > 0)
                    {
                        Game.maxResearch = -Game.researchPoints;
                    }
                    else
                    {
                        bool test = Corot.Research.Research.signsComplete = true;
                    }
                    break;
                case "diplomacy":
                    if (Game.maxResearch > 0)
                    {
                        Game.maxResearch = -Game.researchPoints;
                    }
                    else
                    {
                        bool test = Corot.Research.Research.diplomacyComplete = true;
                    }
                    break;
                case "radio":
                    if (Game.maxResearch > 0)
                    {
                        Game.maxResearch = -Game.researchPoints;
                    }
                    else
                    {
                        bool test = Corot.Research.Research.radioComplete = true;
                    }
                    break;
                case "bunkBeds":
                    if (Game.maxResearch > 0)
                    {
                        Game.maxResearch = -Game.researchPoints;
                    }
                    else
                    {
                        bool test = Corot.Research.Research.bunkBedsComplete = true;
                    }
                    break;
                case "pesticides":
                    if (Game.maxResearch > 0)
                    {
                        Game.maxResearch = -Game.researchPoints;
                    }
                    else
                    {
                        bool test = Corot.Research.Research.pesticidesComplete= true;
                    }
                    break;
                case "fortifyWalls":
                    if (Game.maxResearch > 0)
                    {
                        Game.maxResearch = -Game.researchPoints;
                    }
                    else
                    {
                        bool test = Corot.Research.Research.fortifyWallsComplete = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private void zombieVitalClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Zombie Vitals");
            Game.activeResearch = "zombieVitals";
        }

        private void headshotClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Headshot");
            Game.activeResearch = "headshot";
        }

        private void antiVenomClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Antivenom");
            Game.activeResearch = "antivenom";
        }

        private void signsClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Signs");
            Game.activeResearch = "signs";
        }

        private void diplomacyClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Diplomacy");
            Game.activeResearch = "diplomacy";
        }

        private void radioClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Radio");
            Game.activeResearch = "radio";
        }

        private void bunkBedsClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Bunk Beds");
            Game.activeResearch = "bunkBeds";
        }

        private void pesticidesClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Pesticides");
            Game.activeResearch = "pesticides";
        }

        private void fortifyWallsClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Fortify Walls");
            Game.activeResearch = "fortifyWalls";
        }

    }
}
