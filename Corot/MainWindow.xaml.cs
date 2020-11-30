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
            Console.WriteLine($"Day {game.day}\n~~~~~~~\n");
            game.day = game.day + 1;
            dayHeader.Header = ("Day #" + game.day);
            foodHeader.Header = ("Food #" + game.food);
            baseDefence.calculateDefense();

            //Population();
            populationHeader.Header = ("Population #" + Game.townPopulation.Count());
            MenuItem newExistMenuItem = (MenuItem)this.populationHeader;

            newExistMenuItem.Items.Clear();

            for (int i = 0; i < Game.townPopulation.Count(); i++)
            {
                MenuItem newMenuItem2 = new MenuItem();
                newMenuItem2.Header = Game.townPopulation[i].GetType().Name;
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
        /*
        public void Population()
        {
            for (int i=0; i <= Game.townPopulation.Count(); i++)
            {
                game.townPopulation.Add(person);
            }

            Game.townPopulation.Count() = game.townPopulation.Count();

            Console.WriteLine(game.townPopulation);
        }
        */
    }
}
