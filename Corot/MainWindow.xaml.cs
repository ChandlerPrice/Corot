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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;

        public MainWindow()
        {
            InitializeComponent();
            game = new Game();
            game.day = 1;
            game.population = 1;
            game.food = 5;
        }

        public void NextDay(object sender, RoutedEventArgs e)
        {
            //Update Day
            game.day = game.day + 1;
            dayHeader.Header = ("Day #" + game.day);
            foodHeader.Header = ("Food #" + game.food);

            Population();
            populationHeader.Header = ("Population #" + game.population);

            P1.Header = (game.townPopulation[0].GetType().Name);
            P2.Header = (game.townPopulation[1].GetType().Name);

            //Call random events
            game.DailyEvent();

            //Remove food
            if (game.food < game.population)
            {

            }
            else
            {
                game.food -= game.population;
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

        public void Population()
        {
            People p1 = new People(2, 2, 2, 2, 2, true, false, 0, "N/A", "N/A");
            People p2 = new People();

<<<<<<< HEAD
            game.townPopulation.Add(p1);
            game.townPopulation.Add(p2);
            game.population = game.townPopulation.Count();
=======
            townPopulation.Add(p1);
            townPopulation.Add(p2);
            Console.WriteLine(townPopulation);

            int totalPopulation = 1;

            for (int i=0; i <= totalPopulation; i++)
            {
                People person = new People();
                townPopulation.Add(person);
            }
            Console.WriteLine(townPopulation);
<<<<<<< Updated upstream
=======
>>>>>>> 4d1a5fb8f007e0acc1b85c2429af97e528b29981
>>>>>>> Stashed changes
        }
    }
}
